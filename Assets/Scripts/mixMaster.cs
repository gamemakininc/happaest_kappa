using UnityEngine;
using System.Collections;

public class mixMaster : MonoBehaviour
{
    public static mixMaster Instance { get; private set; }

    public AudioSource as0;
    public AudioSource as1;
    public bool swapBool;
    public AudioClip[] soundtrack;
    //0 main menu theme
    //1 briefing theme
    //2 fitting menu theme
    //3 hangar theme
    //4 save menu theme
    //============================= the following are faction themes aka the gameplay songs should be 2+min or loopable
    //5 vulpie theme (tribal themed)
    //6 PP theme 
    //7 solarin theme 
    //8 TL0 theme (industrial)
    public bool oneshot;//retrigger prevention
    public int nTrack; //holds next track value
    public int cTrack; //holds current track value
    public int pTrack; //??
    public float swapf0;
    public float swapf1;
    // Start is called before the first frame update
    private void Awake()
    {// make shure the singlet remains unas
        if (Instance == null)
        {//
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //set swaps
        swapBool = true;
        oneshot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (nTrack != cTrack ) 
        {
            if (swapBool == true)
            {
                //make shure bilth sourcer are active
                if (as1.enabled == false || as0.enabled == false) { as1.enabled = true; as0.enabled = true; }
                //start track
                if (oneshot == true) 
                {
                    oneshot = false; 
                    as0.loop= true; 
                    as0.clip=(soundtrack[nTrack]);
                    as0.Play();
                    //crossfadeset values
                    StartCoroutine(MMSwap());
                }
                //if fade complete set current track switch swapbool so next track triggers on other output
                if (swapf1 <= 0) { cTrack = nTrack; as1.enabled = false; swapBool = false; Debug.Log("MM swap1"); }
            }
            else if (swapBool == false) {
                //make shure bolth tracks active
                if (as1.enabled == false || as1.enabled == false) { as1.enabled = true; as1.enabled = true;}
                //start track
                if (oneshot == false) 
                {
                    oneshot = true; 
                    as1.loop = true; 
                    as1.clip = (soundtrack[nTrack]); 
                    as1.Play();
                    //crossfade set values
                    StartCoroutine(MMSwap2());
                }
                //if fade complete set current track switch swapbool so next track triggers on other output
                if (swapf0 <= 0) { cTrack = nTrack; as0.enabled = false; swapBool = true; Debug.Log("MM swap2"); }

            }
        }
        //negative number prevention.
        if (swapf0 < 0) { swapf0 = 0; }
        if (swapf1 < 0 ) { swapf1 = 0; }
        //apply volume values
        as0.volume = swapf0;
        as1.volume = swapf1;
    }

    //Coroutine editions of crossfades
    IEnumerator MMSwap()
    {
        while (swapf0 <= ObserverScript.Instance.mvol || swapf1 > 0)
        {
            swapf0 += Time.deltaTime * 0.5f;
            swapf1 += Time.deltaTime * -0.5f;
            yield return new WaitForEndOfFrame();
        }
        Mathf.Clamp(swapf0, 0.0f, ObserverScript.Instance.mvol);
        Mathf.Clamp(swapf1, 0.0f, ObserverScript.Instance.mvol);

        yield return null;
    }
    IEnumerator MMSwap2()
    {
        while (swapf1 <= ObserverScript.Instance.mvol || swapf0 > 0)
        {
            swapf1 += Time.deltaTime * 0.5f;
            swapf0 += Time.deltaTime * -0.5f;
            yield return new WaitForEndOfFrame();
        }
        Mathf.Clamp(swapf0, 0.0f, ObserverScript.Instance.mvol);
        Mathf.Clamp(swapf1, 0.0f, ObserverScript.Instance.mvol);

        yield return null;
    }
}
