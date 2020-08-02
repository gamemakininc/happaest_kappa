using UnityEngine;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour
{
    public Slider mVolSli;
    public Slider sfxVolSli;
    public Toggle mouseAim;

    // Start is called before the first frame update
    void Start()
    {
        //set sliders from vars in observer script
        mVolSli.value = ObserverScript.Instance.mvol;
        sfxVolSli.value = ObserverScript.Instance.sfxvol;
    }

    // Update is called once per frame
    void Update()
    {
        //set vars in observer script from sliders
        ObserverScript.Instance.mvol = mVolSli.value;
        ObserverScript.Instance.sfxvol = sfxVolSli.value;
    }
    public void applybtn() 
    {
        //set vars in observer script from sliders
        ObserverScript.Instance.mvol = mVolSli.value;
        ObserverScript.Instance.sfxvol = sfxVolSli.value;
        //set toggle variables
        ObserverScript.Instance.mouseAiming = mouseAim.isOn;

    }
}
