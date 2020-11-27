using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class settingsMenu : MonoBehaviour
{
    public Dropdown resolutions;
    public Slider mVolSli;
    public Slider sfxVolSli;
    public Toggle fsToggle;
    public Toggle mouseAim;
    public Button[] rebindsBtn;
    public Text[] keyText;
    public inputManedger im;
    public KeyCode[] keyBinds;
    public int intkey;
    public Text fovPaste;
    public Slider fovSlider;

    public GameObject confDialogue;
    public Button btnConfirm;
    public Button btnRevert;
    public Text txtResetTimer;
    bool confOpen;
    int T;
    // Start is called before the first frame update
    void Start()
    {
        im = FindObjectOfType<inputManedger>();
        //set sliders from vars in observer script
        mVolSli.value = ObserverScript.Instance.mvol;
        sfxVolSli.value = ObserverScript.Instance.sfxvol;
        keyBinds = ObserverScript.Instance.keybinds;

        rebindsBtn[0].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[0].name, 0); });
        rebindsBtn[1].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[1].name, 1); });
        rebindsBtn[2].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[2].name, 2); });
        rebindsBtn[3].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[3].name, 3); });
        rebindsBtn[4].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[4].name, 4); });
        rebindsBtn[5].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[5].name, 5); });
        rebindsBtn[6].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[6].name, 6); });
        rebindsBtn[7].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[7].name, 7); });
        rebindsBtn[8].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[8].name, 8); });
        rebindsBtn[9].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[9].name, 9); });
        rebindsBtn[10].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[10].name, 10); });
        rebindsBtn[11].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[11].name, 11); });
        rebindsBtn[12].GetComponent<Button>().onClick.AddListener(() => { startRebindFor(rebindsBtn[12].name, 12); });

    }
    string keyToRebind;
    void startRebindFor(string keyName, int keyloc) 
    {
        Debug.Log("start rebind for: " + keyName +" id: "+keyloc);
        keyToRebind = keyName;
        intkey = keyloc;

    }
    // Update is called once per frame
    void Update()
    {
        
        float fov = fovSlider.value;
        int ifov;
        ifov = Mathf.RoundToInt (fov);
        fovPaste.text= (""+ifov);
        //set vars in observer script from sliders
        ObserverScript.Instance.mvol = mVolSli.value;
        ObserverScript.Instance.sfxvol = sfxVolSli.value;
        if (mixMaster.Instance.swapBool == true)
        {
            mixMaster.Instance.as1.volume = ObserverScript.Instance.mvol;
        }
        else if (mixMaster.Instance.swapBool == false)
        {
            mixMaster.Instance.as0.volume = ObserverScript.Instance.mvol;
        }
        keyText[0].text = keyBinds[0].ToString();
        keyText[1].text = keyBinds[1].ToString();
        keyText[2].text = keyBinds[2].ToString();
        keyText[3].text = keyBinds[3].ToString();
        keyText[4].text = keyBinds[4].ToString();
        keyText[5].text = keyBinds[5].ToString();
        keyText[6].text = keyBinds[6].ToString();
        keyText[7].text = keyBinds[7].ToString();
        keyText[8].text = keyBinds[8].ToString();
        keyText[9].text = keyBinds[9].ToString();
        keyText[10].text = keyBinds[10].ToString();
        keyText[11].text = keyBinds[11].ToString();
        keyText[12].text = keyBinds[12].ToString();

        if (keyToRebind != null) 
        {
            if (Input.anyKeyDown) 
            {
                //what key was pressed

                //loop through all keys
                Array kcs = Enum.GetValues(typeof(KeyCode));
                foreach (KeyCode kc in kcs) 
                {
                    if (Input.GetKeyDown(kc)) 
                    {
                        //yes
                        keyBinds[intkey] = kc;
                        //im.setButtonForKey(keyToRebind, kc);
                        Debug.Log("keyText rebound: " + keyToRebind+" with: "+kc);
                        keyToRebind = null;

                        break;
                    }
                }
            }
        }
        if (mouseAim.isOn == true)
        {
            //dissable rebinds for laser aimer if not set to use
            rebindsBtn[7].interactable = false;
            rebindsBtn[8].interactable = false;
            rebindsBtn[9].interactable = false;
            rebindsBtn[10].interactable = false;
        }
        else if (mouseAim.isOn == false)
        {
            //enable rebinds for laser aimer if not set to use
            rebindsBtn[7].interactable = true;
            rebindsBtn[8].interactable = true;
            rebindsBtn[9].interactable = true;
            rebindsBtn[10].interactable = true;
        }
    }
    public void applybtn()
    {
        bool B;
        B = fsToggle.isOn;
        //uses toggle to swap between full screen and windowed.
        if (B != ObserverScript.Instance.fs|| resolutions.value != ObserverScript.Instance.resoSelect)
        {
            switch (resolutions.value) 
            {
                case 0:
                    Screen.SetResolution(1280,720, B);
                    break;
                case 1:
                    Screen.SetResolution(1366, 768, B);

                    break;
                case 2:
                    Screen.SetResolution(1600, 900, B);

                    break;
                case 3:
                    Screen.SetResolution(1920, 1080, B);

                    break;
                case 4:
                    Screen.SetResolution(2048, 1152, B);

                    break;
                case 5:
                    Screen.SetResolution(2560, 1440, B);

                    break;
                case 6:
                    Screen.SetResolution(2880, 1620, B);

                    break;

            }

            StartCoroutine(confermWait());
        }
        //set vars in observer script from sliders
        ObserverScript.Instance.mvol = mVolSli.value;
        ObserverScript.Instance.sfxvol = sfxVolSli.value;
        //set toggle variables
        ObserverScript.Instance.mouseAiming = mouseAim.isOn;
        ObserverScript.Instance.keybinds = keyBinds;
        im.updateKeys();
        FindObjectOfType<savescript>().saveSettings();
    }
    public void defaults() 
    {
        //reset keybinds
        keyBinds[0] = KeyCode.A;
        keyBinds[1] = KeyCode.W;
        keyBinds[2] = KeyCode.S;
        keyBinds[3] = KeyCode.F;
        keyBinds[4] = KeyCode.Mouse0;
        keyBinds[5] = KeyCode.Mouse1;
        keyBinds[6] = KeyCode.Mouse2;
        keyBinds[7] = KeyCode.LeftArrow;
        keyBinds[8] = KeyCode.UpArrow;
        keyBinds[9] = KeyCode.DownArrow;
        keyBinds[10] = KeyCode.RightArrow;
        keyBinds[11] = KeyCode.Space;
        keyBinds[12] = KeyCode.Q;
        ObserverScript.Instance.keybinds = keyBinds;
        im.updateKeys();
        //reset volume
        mVolSli.value = 1;
        sfxVolSli.value = 1;
        ObserverScript.Instance.mvol = mVolSli.value;
        ObserverScript.Instance.sfxvol = sfxVolSli.value;
        if (mixMaster.Instance.swapBool == true)
        {
            mixMaster.Instance.as1.volume = ObserverScript.Instance.mvol;
        }
        else if (mixMaster.Instance.swapBool == false)
        {
            mixMaster.Instance.as0.volume = ObserverScript.Instance.mvol;
        }
        //set mouse aim
        mouseAim.isOn = true;
        ObserverScript.Instance.mouseAiming = mouseAim.isOn;
        ObserverScript.Instance.fs = true;
        Screen.SetResolution(1920, 1080, true);

    }
    IEnumerator confermWait() 
    {
        //make shure T is reset
        T = 0;
        //enable confermation dialogue
        confDialogue.SetActive(true);
        //set code side tracker for dialogue opem
        confOpen = true;

        //timer to auto close and video changes
        while (T <= 5) 
        {
            Debug.Log("T=" + T);
            if (T == 0) { txtResetTimer.text = ("(5)"); }
            if (T == 1) { txtResetTimer.text = ("(4)"); }
            if (T == 2) { txtResetTimer.text = ("(3)"); }
            if (T == 3) { txtResetTimer.text = ("(2)"); }
            if (T == 4) { txtResetTimer.text = ("(1)"); }
            if (T == 5) { txtResetTimer.text = ("(0)"); }
            yield return 0;
            yield return new WaitForSeconds(1);
            T++;
        }
        //after timer ends check if accept pressed
        if (onePressed == true)
        {
            if (fsToggle.isOn == true) 
            { ObserverScript.Instance.fs = true; }
            else { ObserverScript.Instance.fs = false; }
            ObserverScript.Instance.resoSelect = resolutions.value;
        }
        //if not reset to saved setting
        else
        {
            fsToggle.isOn = ObserverScript.Instance.fs;
            resolutions.value = ObserverScript.Instance.resoSelect;
            switch (resolutions.value)
            {
                case 0:
                    Screen.SetResolution(1280, 720, fsToggle.isOn);
                    break;
                case 1:
                    Screen.SetResolution(1366, 768, fsToggle.isOn);

                    break;
                case 2:
                    Screen.SetResolution(1600, 900, fsToggle.isOn);

                    break;
                case 3:
                    Screen.SetResolution(1920, 1080, fsToggle.isOn);

                    break;
                case 4:
                    Screen.SetResolution(2048, 1152, fsToggle.isOn);

                    break;
                case 5:
                    Screen.SetResolution(2560, 1440, fsToggle.isOn);

                    break;
                case 6:
                    Screen.SetResolution(2880, 1620, fsToggle.isOn);

                    break;

            }

            //reload active scene   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //set code side tracker for dialogue opem
        confOpen = false;
        //dissable confermation dialogue
        confDialogue.SetActive(false);
    }
    bool onePressed;
    public void one()
    {
        //set variable to say accept pressed
        onePressed = true;
        //end the timer early
        if (confOpen == true) { T = 6; }
    }
    public void two()
    {
        //end the timer early
        if (confOpen == true) { T = 6; }
    }

}
