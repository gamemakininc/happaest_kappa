using System.Collections.Generic;
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
        kb = ObserverScript.Instance.keybinds;
        keyBinds = new Dictionary<string, KeyCode>();
        //movement keys for player
        keyBinds["left"] = kb[0];
        keyBinds["up"] = kb[1];
        keyBinds["down"] = kb[2];
        keyBinds["right"] = kb[3];
        //fire keys
        keyBinds["fire1"]=kb[4];
        keyBinds["fire2"]=kb[5];
        keyBinds["fire3"]=kb[6];
        //movement keys for crosshair
        keyBinds["cleft"] = kb[7];
        keyBinds["cup"] = kb[8];
        keyBinds["cdown"] = kb[9];
        keyBinds["cright"] = kb[10];
    }
    Dictionary<string, KeyCode> keyBinds;

    public bool GetButtonDown( string buttonName ) 
    {
        if (keyBinds.ContainsKey(buttonName) == false)
        {
            Debug.LogError("inputManedger::GetButtonDown -- No button named: " + buttonName);
            return false;
        }
        return Input.GetKey(keyBinds[buttonName]);
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
    // Update is called once per frame
    void Update()
    {
        //horizontal calculation
        if (GetButtonDown("left") == true) { Horizontal = -1; }
        if (GetButtonDown("right") == true) { Horizontal = 1; }
        //vertical calculation
        if (GetButtonDown("up") == true ) { Vertical = 1; }
        if (GetButtonDown("down") == true ) { Vertical = -1; }
        //reset
        if (GetButtonDown("left") == false && GetButtonDown("right") == false&& Horizontal > 0.01) 
        { 
            Horizontal = -slideAmt*Time.deltaTime;
            if (Horizontal >= -0.1 && Horizontal <= 0.1) { Horizontal = 0; }
        }
        if (GetButtonDown("left") == false && GetButtonDown("right") == false&& Horizontal < -0.01) 
        { 
            Horizontal = slideAmt * Time.deltaTime; ;
            if (Horizontal >= -0.1&& Horizontal<=0.1) { Horizontal = 0; }
        }
        if (GetButtonDown("up")==false && GetButtonDown("down") == false&& Vertical > 0.01) 
        { 
            Vertical = -slideAmt * Time.deltaTime; ;
            if (Horizontal >= -0.1 && Horizontal <= 0.1) { Vertical = 0; }
        }
        if (GetButtonDown("up") == false && GetButtonDown("down") == false&& Vertical < -0.01) 
        {
            Vertical = slideAmt * Time.deltaTime; ;
            if (Horizontal >= -0.1 && Horizontal <= 0.1) { Vertical = 0; }
        }
    }
}
