using UnityEngine;
using UnityEngine.UI;
using System;

public class settingsMenu : MonoBehaviour
{
    public Slider mVolSli;
    public Slider sfxVolSli;
    public Toggle mouseAim;
    public Button[] rebindsBtn;
    public Text[] keyText;
    public inputManedger im;
    public KeyCode[] keyBinds;
    public int intkey;

    // Start is called before the first frame update
    void Start()
    {
        im = FindObjectOfType<inputManedger>();
        //set sliders from vars in observer script
        mVolSli.value = ObserverScript.Instance.mvol;
        sfxVolSli.value = ObserverScript.Instance.sfxvol;
        keyBinds = ObserverScript.Instance.keybinds;
        
        rebindsBtn[0].GetComponent<Button>().onClick.AddListener( ()=> { startRebindFor(rebindsBtn[0].name, 0); });
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

    }
    string keyToRebind;
    int keyLoc;
    void startRebindFor(string keyName, int keyloc) 
    {
        Debug.Log("start rebind for: " + keyName +" id: "+keyloc);
        keyToRebind = keyName;
        intkey = keyloc;

    }
    // Update is called once per frame
    void Update()
    {
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
        keyBinds[0] = KeyCode.W;
        keyBinds[0] = KeyCode.S;
        keyBinds[0] = KeyCode.F;
        keyBinds[0] = KeyCode.Mouse0;
        keyBinds[0] = KeyCode.Mouse1;
        keyBinds[0] = KeyCode.Mouse2;
        keyBinds[0] = KeyCode.LeftArrow;
        keyBinds[0] = KeyCode.UpArrow;
        keyBinds[0] = KeyCode.DownArrow;
        keyBinds[0] = KeyCode.RightArrow;
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
    }
}
