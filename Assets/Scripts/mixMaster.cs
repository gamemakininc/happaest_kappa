using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixMaster : MonoBehaviour
{
    public static mixMaster Instance { get; private set; }

    public AudioSource as0;
    public AudioSource as1;
    private bool swapBool;
    public AudioClip[] soundtrack;
    public bool oneshot;
    public int nTrack;
    public int cTrack;
    public int pTrack;
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
        swapf0 = 0;
        swapf1 = 1;
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
                if (oneshot == true) { oneshot = false; as0.loop= true; as0.clip=(soundtrack[nTrack]); as0.Play(); }
                //crossfadeset values
                swapf0 += 0.5f * Time.deltaTime;
                swapf1 += -0.5f * Time.deltaTime;
                //crossfade apply values
                as0.volume = swapf0;
                as1.volume = swapf1;
                //if fade complete set current track switch swapbool so next track triggers on other output
                if (swapf0 >= 1 && swapf1 <= 0) { cTrack = nTrack; as1.enabled = false; swapBool = false; }
            }
            if (swapBool == false) {
                //make shure bolth tracks active
                if (as1.enabled == false || as1.enabled == false) { as1.enabled = true; as1.enabled = true;}
                //start track
                if (oneshot == false) { oneshot = true; as1.loop = true; as1.clip = (soundtrack[nTrack]); as1.Play(); }
                //crossfade set values
                swapf1 += 0.5f * Time.deltaTime;
                swapf0 += -0.5f * Time.deltaTime;
                //crossfade apply values
                as0.volume = swapf0;
                as1.volume = swapf1;
                //if fade complete set current track switch swapbool so next track triggers on other output
                if (swapf1 >= 1 && swapf0 <= 0) { cTrack = nTrack; as0.enabled = false; swapBool = true; }

            }
        }
    }
}
