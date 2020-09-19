using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 

public class GlitchShaderVariables : MonoBehaviour
{
    public FloatParameter drift = new FloatParameter { value = 0.0f };
    public FloatParameter jitter = new FloatParameter { value = 0.0f };
    public FloatParameter cutoff = new FloatParameter { value = 0.0f };
    public FloatParameter jump = new FloatParameter { value = 0.0f };
    private Texture2D _trashTex;

    private FloatParameter addDrift = new FloatParameter { value = 0.0f };
    private FloatParameter addJitter = new FloatParameter { value = 0.0f };
    private FloatParameter addCutoff = new FloatParameter { value = 0.0f };
    private FloatParameter addJump = new FloatParameter { value = 0.0f };

    private FloatParameter driftBuzz = new FloatParameter { value = 0.0f }; //Range 0~1
    private FloatParameter jitterBuzz = new FloatParameter { value = 0.0f }; //Range 0~1
    private FloatParameter cutoffBuzz = new FloatParameter { value = 0.0f }; //Range 0~1
    private FloatParameter jumpBuzz = new FloatParameter { value = 0.0f }; //Range -1~1

    PostProcessVolume m_volume;
    GlitchShader glitch;
    private FloatParameter margin = new FloatParameter { value = 0.0f };

    public bool constantGlitch;

    void Start()
    {
        m_volume = gameObject.GetComponent<PostProcessVolume>();

        _trashTex = new Texture2D(1, 720, TextureFormat.ARGB32, false);
        UpdateTexture();

        //StartCoroutine(AddGlitch(new FloatParameter { value = 0.3f }, new FloatParameter { value = 0.5f }, new FloatParameter { value = 0.0f }, new FloatParameter { value = 0.1f })); //Debug, remove after use
    }

    void FixedUpdate()
    {
        if(Random.Range(0.0f, 1.0f) > 0.8 && margin != 0)
            StartCoroutine(GlitchBuzz(margin));

        //Use to test effects
        /*if(Input.GetKeyDown(KeyCode.P))
            StartCoroutine(AddGlitch(new FloatParameter { value = 0.3f }, new FloatParameter { value = 0.5f }, new FloatParameter { value = 0.0f }, new FloatParameter { value = 0.1f }));

        if (Input.GetKeyDown(KeyCode.O) && margin.value == 0)
            margin.value = 0.15f;
        else if(Input.GetKeyDown(KeyCode.O) && margin.value != 0){
            margin.value = 0.00f;
            driftBuzz.value = 0.0f;
            jitterBuzz.value = 0.0f;
            cutoffBuzz.value = 0.0f;
            jumpBuzz.value = 0.0f;
        }*/

        ControlGlitch();
    }

    //Adds a burst of glitch that dies down, call to add glitch
    public void _AddGlitch(float _drift, float _jitter, float _cutoff, float _jump)
    {
        StartCoroutine(AddGlitch(new FloatParameter { value = _drift }, new FloatParameter { value = _jitter }, new FloatParameter { value = _cutoff }, new FloatParameter { value = _jump }));
    }
    IEnumerator AddGlitch(FloatParameter _drift, FloatParameter _jitter, FloatParameter _cutoff, FloatParameter _jump)
    {
        addDrift = _drift;
        addJitter = _jitter;
        addCutoff = _cutoff;
        addJump = _jump;
        float _addDrift = addDrift;
        float _addJitter = addJitter;
        float _addCutoff = addCutoff;
        float _addJump = addJump;

        float elapsedTime = 0;
        float timer = 0.8f;

        margin = new FloatParameter { value = 0.15f };

        //Glitch effects reduces over time
        while (elapsedTime < timer)
        {
            _addDrift = Mathf.Lerp(_addDrift, 0, elapsedTime / timer);
            _addJitter = Mathf.Lerp(_addJitter, 0, elapsedTime / timer);
            _addCutoff = Mathf.Lerp(_addCutoff, 0, elapsedTime / timer);
            _addJump = Mathf.Lerp(_addJump, 0, elapsedTime / timer);

            addDrift.value = _addDrift;
            addJitter.value = _addJitter;
            addCutoff.value = _addCutoff;
            addJump.value = _addJump;

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        addDrift = new FloatParameter { value = 0.0f };
        addJitter = new FloatParameter { value = 0.0f };
        addCutoff = new FloatParameter { value = 0.0f };
        addJump = new FloatParameter { value = 0.0f };

        //Resets GlitchBuzz()
        margin = new FloatParameter { value = 0.0f };
        driftBuzz.value = 0.0f;
        jitterBuzz.value = 0.0f;
        cutoffBuzz.value = 0.0f;
        jumpBuzz.value = 0.0f;
        //print("Drift = drift: " + drift.value + " + addDrift: " + addDrift.value + " + driftBuzz: " + driftBuzz.value);

        yield return null;
    }

    //Maintains a level of glitchiness
    IEnumerator GlitchBuzz(FloatParameter _margin) //Needs random value for each variable
    {
        float _random = Random.Range(0.0f, _margin * 0.5f);
        driftBuzz = new FloatParameter { value = drift + _random };
        jitterBuzz = new FloatParameter { value = jitter + _random };
        //cutoffBuzz = new FloatParameter { value = cutoff + _random };
        jumpBuzz = new FloatParameter { value = jump + _random - _random * 0.5f };
        UpdateTexture();

        //yield return new WaitForSecondsRealtime(0.05f);
        yield return null;
    }

    void ControlGlitch() //Applies Changes to shader values
    {
        if(m_volume != null)
        {
            if(m_volume.profile.TryGetSettings(out glitch))
            {
                glitch.drift.value = drift + addDrift + driftBuzz;
                glitch.jitter.value = jitter + addJitter + jitterBuzz;
                glitch.cutoff.value = cutoff + addCutoff + cutoffBuzz;
                glitch.jump.value = jump + addJump + jumpBuzz;
                glitch.trashTex.value = new TextureParameter { value = _trashTex };
            }
        }
    }

    void UpdateTexture()
    {
        var color = RandomColor();

        for (var y = 0; y < _trashTex.height; y++)
        {
            for (var x = 0; x < _trashTex.width; x++)
            {
                color = RandomColor();
                _trashTex.SetPixel(x, y, color);
            }
        }

        _trashTex.Apply();
    }

    static Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, Random.value);
    }
}
