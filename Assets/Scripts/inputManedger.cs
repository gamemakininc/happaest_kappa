using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//this is a component of observer.
[RequireComponent(typeof(ObserverScript))]
public class inputManedger : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;
    public float slideAmt;
    public KeyCode[] kb;
    // Start is called before the first frame update
    void Start()
    {
        updateKeys();
    }
    Dictionary<string, KeyCode> keyBinds;
    public void updateKeys()
    {
        kb = ObserverScript.Instance.keybinds;
        keyBinds = new Dictionary<string, KeyCode>();
        //movement keys for player
        keyBinds["left"] = kb[0];
        keyBinds["up"] = kb[1];
        keyBinds["down"] = kb[2];
        keyBinds["right"] = kb[3];
        //fire keys
        keyBinds["fire1"] = kb[4];
        keyBinds["fire2"] = kb[5];
        keyBinds["fire3"] = kb[6];
        //movement keys for crosshair
        keyBinds["cleft"] = kb[7];
        keyBinds["cup"] = kb[8];
        keyBinds["cdown"] = kb[9];
        keyBinds["cright"] = kb[10];
    }
    public bool GetButtonDownH( string buttonName ) 
    {//used for key hold
        if (keyBinds.ContainsKey(buttonName) == false)
        {
            Debug.LogError("inputManedger::GetButtonDown -- No button named: " + buttonName);
            return false;
        }
        return Input.GetKey(keyBinds[buttonName]);
    }
    public bool GetButtonDown(string buttonName)
    {//used for single fire 
        if (keyBinds.ContainsKey(buttonName) == false)
        {
            Debug.LogError("inputManedger::GetButtonDown -- No button named: " + buttonName);
            return false;
        }
        return Input.GetKeyDown(keyBinds[buttonName]);
    }
    public float getAxis(string axisname) 
    {
        if (axisname == "Horizontal")
        {
            return Horizontal;
        }
        else if (axisname == "Vertical")
        {
            return Vertical;
        }
        else
        {
            Debug.LogError("inputManedger::GetButtonDown -- No axis named: " + axisname);
            return 0;
        }

    }
    void Update()
    {
        //horizontal calculation
        if (GetButtonDownH("left") == true) { Horizontal = -1; }
        if (GetButtonDownH("right") == true) { Horizontal = 1; }
        //vertical calculation
        if (GetButtonDownH("up") == true ) { Vertical = 1; }
        if (GetButtonDownH("down") == true ) { Vertical = -1; }
        //reset
        if (GetButtonDownH("left") == false && GetButtonDownH("right") == false&& Horizontal > 0.01) 
        { 
            Horizontal -= slideAmt*Time.deltaTime;
            if (Horizontal >= -0.01 && Horizontal <= 0.01) { Horizontal = 0; }
        }
        if (GetButtonDownH("left") == false && GetButtonDownH("right") == false&& Horizontal < -0.01) 
        { 
            Horizontal += slideAmt * Time.deltaTime; ;
            if (Horizontal >= -0.01&& Horizontal<=0.01) { Horizontal = 0; }
        }
        if (GetButtonDownH("up")==false && GetButtonDownH("down") == false&& Vertical > 0.01) 
        { 
            Vertical -= slideAmt * Time.deltaTime; ;
            if (Horizontal >= -0.01 && Horizontal <= 0.01) { Vertical = 0; }
        }
        if (GetButtonDownH("up") == false && GetButtonDownH("down") == false&& Vertical < -0.01) 
        {
            Vertical += slideAmt * Time.deltaTime; ;
            if (Horizontal >= -0.01 && Horizontal <= 0.01) { Vertical = 0; }
        }
    }
}
