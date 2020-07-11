using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class eventSystem : MonoBehaviour
{
    public Text btn1Txt;
    public Text btn2Txt;
    public Sprite[] speakers;
    public Transform endPoint;
    public GameObject slider;
    public int eventLingth;
    public bool typeing;
    public float letterPause;
    public string[] message;
    public Text speechBox;
    public int msgselect;
    public GameObject btn;
    public bool eventAllreadyTriggered=false;
    public bool eventTriedFitting=false;
    public bool eventTriedBriefing=false;
    public bool eventTriedInterrupt = false;
    //unlocks 
    /*
      should corrispond to 'item designator'
      zero should allways be true!
      0          default unlocks(slot clears )
      1-3,7-9    shields
      4-6,10-12  health
      13-18      speed mods
      19-24      misc mods
      25-27      missiles
      28-35      ships (last two should have spechal unlock conditions)
      36         guns (should be last unlock)
    */
    public bool[] unlocks;
    private int swapint;
    private bool swapBool=false;
    private int counter;
    //locators to be set in unity
    public bool hangar;//implemented with mission interrupt scene
    public bool fitting;
    public bool briefing;
    public void fittingLoadEvents()
        //aircraft unlocks than hp buff mods
    {
        //import variables
        eventAllreadyTriggered = ObserverScript.Instance.bookmark0;
        eventTriedFitting = ObserverScript.Instance.bookmark1;
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //reset swapbool
        swapBool = false;
        //check for event elegitability
        if (eventAllreadyTriggered == true) {/*do nothing*/ }
        else if (eventTriedFitting == true) {/*do nothing*/ }
        else if (ObserverScript.Instance.levelsCleared <= 0) {/*do nothing*/}
        //poll RNG
        else if (swapint <= 60)
        {

            ObserverScript.Instance.bookmark0 = true;
            counter = 0;
            //should skip loop if all ships unlocked
            if (unlocks[28] == true && unlocks[29] == true && unlocks[30] == true && unlocks[31] == true && unlocks[32] == true && unlocks[33] == true) { swapBool = true; }
            //loop till something unlocks?    
            while (swapBool == false)
            {
                //set rng
                swapint = Random.Range(28, 33);
                //unlock something (hopefully)
                if (unlocks[28] == false && swapint == 28) 
                { 
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[28] = true;
                    msgselect = 0;
                    eventLingth = 1;
                    eventStart();
                }
                if (unlocks[29] == false && swapint == 29)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[29] = true;
                    msgselect = 2;
                    eventLingth = 3;
                    eventStart();
                }
                if (unlocks[30] == false && swapint == 30)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[30] = true;
                    msgselect = 4;
                    eventLingth = 5;
                    eventStart();
                }
                if (unlocks[31] == false && swapint == 31)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[31] = true;
                    msgselect = 6;
                    eventLingth = 7;
                    eventStart();
                }
                if (unlocks[32] == false && swapint == 32)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[32] = true;
                    msgselect = 8;
                    eventLingth = 9;
                    eventStart();
                }
                if (unlocks[33] == false && swapint == 33)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[33] = true;
                    msgselect = 10;
                    eventLingth = 11;
                    eventStart();
                }
                counter++;

                //escape clause incase number dosent come up in reasonable time.
                if (counter >= 20) {  Debug.Log("attempted to unlock and failed"); break; }
                if (swapBool == true) { Debug.Log("unlocked" + swapint); }
            }
            //check if all ships unlocked
            if (unlocks[28] == true && unlocks[29] == true && unlocks[30] == true && unlocks[31] == true && unlocks[32] == true && unlocks[33] == true) 
            {
                counter = 0;
                swapBool = false;

                //loop till something unlocks?   
                while (swapBool == false)
                {
                    //set rng
                    swapint = Random.Range(1, 6);
                    //unlock something (hopefully)
                    if (unlocks[1] == false && swapint == 1)
                    {
                        swapBool = true;
                        //eventAllreadyTriggered=true;
                        ObserverScript.Instance.unlocks[1] = true;
                        msgselect = 12;
                        eventLingth = 13;
                        eventStart();
                    }
                    if (unlocks[2] == false && swapint == 2)
                    {
                        swapBool = true;
                        //eventAllreadyTriggered=true;
                        ObserverScript.Instance.unlocks[2] = true;
                        msgselect = 14;
                        eventLingth = 15;
                        eventStart();
                    }
                    if (unlocks[3] == false && swapint == 3)
                    {
                        swapBool = true;
                        //eventAllreadyTriggered=true;
                        ObserverScript.Instance.unlocks[3] = true;
                        msgselect = 16;
                        eventLingth = 17;
                        eventStart();
                    }
                    if (unlocks[4] == false && swapint == 4)
                    {
                        swapBool = true;
                        //eventAllreadyTriggered=true;
                        ObserverScript.Instance.unlocks[4] = true;
                        msgselect = 18;
                        eventLingth = 19;
                        eventStart();
                    }
                    if (unlocks[5] == false && swapint == 5)
                    {
                        swapBool = true;
                        //eventAllreadyTriggered=true;
                        ObserverScript.Instance.unlocks[5] = true;
                        msgselect = 20;
                        eventLingth = 21;
                        eventStart();
                    }
                    if (unlocks[6] == false && swapint == 6)
                    {
                        swapBool = true;
                        //eventAllreadyTriggered=true;
                        ObserverScript.Instance.unlocks[6] = true;
                        msgselect = 22;
                        eventLingth = 23;
                        eventStart();
                    }
                    counter++;
                    //escape clause incase number dosent come up in reasonable time.
                    if (counter >= 20) { Debug.Log("attempted to unlock and failed"); break; }
                    if (swapBool == true) { Debug.Log("unlocked" + swapint); }
                }
            }
        }

        //dissable ability to retrigger
        eventTriedFitting = true;
        //update bookmark (reset on mission completion or fail do not reset on mission start)
        ObserverScript.Instance.bookmark1= eventTriedFitting;
    }
    public void briefingLoadEvents()
    //mod unlocks
    {
        eventAllreadyTriggered = ObserverScript.Instance.bookmark0;
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        eventTriedBriefing = ObserverScript.Instance.bookmark2;
        //check for event elegitability
        if (eventAllreadyTriggered == true) {/*do nothing*/ }
        else if (eventTriedBriefing == true) {/*do nothing*/ }
        else if (ObserverScript.Instance.levelsCleared <= 0) {/*do nothing*/}
        //poll RNG
        else if (swapint <= 60) 
        {
            ObserverScript.Instance.bookmark0 = true;
            //reset swaps
            swapBool = false;
            counter = 0;

            while (swapBool == false)
            {
                //set rng
                swapint = Random.Range(7, 24);
                //unlock something (hopefully)
                if (unlocks[7] == false && swapint == 7)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[7] = true;
                    msgselect = 0;
                    eventLingth = 1;
                    eventStart();
                }
                if (unlocks[8] == false && swapint == 8)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[8] = true;
                    msgselect = 2;
                    eventLingth = 3;
                    eventStart();
                }
                if (unlocks[9] == false && swapint == 9)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[9] = true;
                    msgselect = 4;
                    eventLingth = 5;
                    eventStart();
                }
                if (unlocks[10] == false && swapint == 10)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[10] = true;
                    msgselect = 6;
                    eventLingth = 7;
                    eventStart();
                }
                if (unlocks[11] == false && swapint == 11)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[11] = true;
                    msgselect = 8;
                    eventLingth = 9;
                    eventStart();
                }
                if (unlocks[12] == false && swapint == 12)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[12] = true;
                    msgselect = 10;
                    eventLingth = 11;
                    eventStart();
                }
                if (unlocks[13] == false && swapint == 13)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[13] = true;
                    msgselect = 12;
                    eventLingth = 13;
                    eventStart();
                }
                if (unlocks[14] == false && swapint == 14)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[14] = true;
                    msgselect = 14;
                    eventLingth = 15;
                    eventStart();
                }
                if (unlocks[15] == false && swapint == 15)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[15] = true;
                    msgselect = 16;
                    eventLingth = 17;
                    eventStart();
                }
                if (unlocks[16] == false && swapint == 16)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[16] = true;
                    msgselect = 18;
                    eventLingth = 19;
                    eventStart();
                }
                if (unlocks[17] == false && swapint == 17)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[17] = true;
                    msgselect = 20;
                    eventLingth = 21;
                    eventStart();
                }
                if (unlocks[18] == false && swapint == 18)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[18] = true;
                    msgselect = 22;
                    eventLingth = 23;
                    eventStart();
                }
                if (unlocks[19] == false && swapint == 19)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[19] = true;
                    msgselect = 24;
                    eventLingth = 25;
                    eventStart();
                }
                if (unlocks[20] == false && swapint == 20)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[20] = true;
                    msgselect = 26;
                    eventLingth = 27;
                    eventStart();
                }
                if (unlocks[21] == false && swapint == 21)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[21] = true;
                    msgselect = 28;
                    eventLingth = 29;
                    eventStart();
                }
                if (unlocks[22] == false && swapint == 22)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[22] = true;
                    msgselect = 30;
                    eventLingth = 31;
                    eventStart();
                }
                if (unlocks[23] == false && swapint == 23)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[23] = true;
                    msgselect = 32;
                    eventLingth = 33;
                    eventStart();
                }
                if (unlocks[24] == false && swapint == 24)
                {
                    swapBool = true;
                    //eventAllreadyTriggered=true;
                    ObserverScript.Instance.unlocks[24] = true;
                    msgselect = 34;
                    eventLingth = 35;
                    eventStart();
                }
                counter++;
                //escape clause incase number dosent come up in reasonable time.
                if (counter >= 20) { Debug.Log("attempted to unlock and failed"); break; }
                if (swapBool == true) { Debug.Log("unlocked"+swapint); }
            }
        }
        //dissable ability to retrigger
        eventTriedBriefing = true;
        //update bookmark (reset on mission completion or fail do not reset on mission start)
        ObserverScript.Instance.bookmark2 = eventTriedBriefing;
        ObserverScript.Instance.bookmark0 = eventAllreadyTriggered;
    }
    public void missionInterruptEvents()
    //unlock secret ships later to be moved to 'questlines' and replaced with missiles(with retuned drop rates)
    {

        eventTriedInterrupt = ObserverScript.Instance.bookmark3;
        eventAllreadyTriggered = ObserverScript.Instance.bookmark0;
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //check for event elegitability
        if (eventAllreadyTriggered == true) {/*do nothing*/}
        else if (eventTriedInterrupt==true) {/*do nothing*/}
        else if (ObserverScript.Instance.levelsCleared <= 3) {/*do nothing*/}
        //reroll check not neccicary because trigger is menu change
        //poll RNG
        else if (swapint <= 20)
        { // i would like to make this one launch its own scene later
            btn.GetComponent<Button>().interactable=false;
            ObserverScript.Instance.bookmark0 = true;
            counter = 0;
            while (swapBool == false)
            {
                //set RNG
                swapint = Random.Range(1, 3);
                //if 1 check missiles
                if (swapint == 1 && unlocks[25] == false || unlocks[26] == false || unlocks[27] == false)
                {
                    //check next missile to unlock
                    if (unlocks[25] == false)
                    {
                        //set esSwap to handoff info to 'hangar' scene
                        ObserverScript.Instance.esSwap = 1;
                        //tell loop it is done incase script still runs after ecene change somehow
                        swapBool = true;
                        //change scene
                        FindObjectOfType<Camera>().GetComponent<sceneManager>().hangar();
                    }
                    else if (unlocks[26] == false)
                    {
                        ObserverScript.Instance.esSwap = 2;
                        swapBool = true;
                        FindObjectOfType<Camera>().GetComponent<sceneManager>().hangar();
                    }
                    else if (unlocks[27] == false)
                    {
                        ObserverScript.Instance.esSwap = 3;
                        swapBool = true;
                        FindObjectOfType<Camera>().GetComponent<sceneManager>().hangar();
                    }
                }
                else if (swapint == 2 && unlocks[35] == false || unlocks[34] == false) 
                {
                    if (unlocks[34] == false)
                    {
                        //set esSwap to handoff info to 'hangar' scene
                        ObserverScript.Instance.esSwap = 4;
                        //tell loop it is done incase script still runs after ecene change somehow
                        swapBool = true;
                        //change scene
                        FindObjectOfType<Camera>().GetComponent<sceneManager>().hangar();
                    }
                    else if (unlocks[35] == false) 
                    {
                        //set esSwap to handoff info to 'hangar' scene
                        ObserverScript.Instance.esSwap = 5;
                        //tell loop it is done incase script still runs after ecene change somehow
                        swapBool = true;
                        //change scene
                        FindObjectOfType<Camera>().GetComponent<sceneManager>().hangar();
                    }
                }
                counter++;
                //escape clause incase number dosent come up in reasonable time.
                if (counter >= 20) { Debug.Log("attempted to unlock and failed"); break; }
                if (swapBool == true) { Debug.Log("unlocked" + swapint); }
            }
            //??
            btn.GetComponent<Button>().interactable = true;
        }
        eventTriedInterrupt = true;
        ObserverScript.Instance.bookmark3 = true;
    }
    public void hangarEvents()
    {
        if (swapint == 0) { FindObjectOfType<Camera>().GetComponent<sceneManager>().briefing(); }
        else if (swapint == 1) { missileUnlock1(); msgselect = 0; eventLingth = 4; }
        else if (swapint == 2) { missileUnlock2(); msgselect = 5; eventLingth = 9; }
        else if (swapint == 3) { missileUnlock3(); msgselect = 10; eventLingth = 14; }
        else if (swapint == 3) { shipUnlock1(); msgselect = 15; eventLingth = 19; }
        else if (swapint == 3) { shipUnlock2(); msgselect = 22; eventLingth = 26; }
    }
    public void missileUnlock1()
    {
        if (msgselect == 0) { }
        if (msgselect == 1) { }
        if (msgselect == 2) { }
        if (msgselect == 3) { }
        if (msgselect == 4) { }

    }
    public void missileUnlock2()
    {
        if (msgselect == 5) { }
        if (msgselect == 6) { }
        if (msgselect == 7) { }
        if (msgselect == 8) { }
        if (msgselect == 9) { }
    }
    public void missileUnlock3()
    {
        if (msgselect == 10) { }
        if (msgselect == 11) { }
        if (msgselect == 12) { }
        if (msgselect == 13) { }
        if (msgselect == 14) { }

    }
    public void shipUnlock1()
    {
        if (msgselect == 15) { }
        if (msgselect == 16) { }
        if (msgselect == 17) { }
        if (msgselect == 18) { }
        if (msgselect == 19) { }

    }
    public void shipUnlock2()
    {
        if (msgselect == 20) { }
        if (msgselect == 21) { }
        if (msgselect == 22) { }
        if (msgselect == 23) { }
        if (msgselect == 24) { }

    }

    IEnumerator TypeText()
    {
        //tell button loop is running
        typeing = true;
        //clear text box
        speechBox.text = " ";
        //l00p to fil in the text box letter by letter
        foreach (char letter in message[msgselect].ToCharArray())
        {
            //if text box filled in skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip skip
            if (speechBox.text == message[msgselect]) 
            { break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break;}
            //type a letter
            speechBox.text += letter;
            //wait
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        //tell button loop is over
        typeing = false;
    }
    public void btnpressed() 
    {
        if (hangar==true) 
        {
            if (typeing == true)
            {
                //hopefully bypass the text box fill in
                speechBox.text = message[msgselect];
            }
            if (typeing == false) {  }
        }
        else {
            //if typetext active
            if (typeing == true)
            {
                //hopefully bypass the text box fill in
                speechBox.text = message[msgselect];

            }
            //if waiting for next input
            else if (typeing == false)
            {
                //check if its last page of event script
                if (msgselect >= eventLingth) { eventEnd(); }
                //if its not start next page
                else if (msgselect <= eventLingth) { msgselect++; StartCoroutine(TypeText()); }
            }
        }
    }
    void eventStart()
    {
        //chat menu into frame
        slider.GetComponent<Rigidbody2D>().velocity = new Vector2(slider.GetComponent<Rigidbody2D>().velocity.x, 15);
    }
    void eventEnd() 
    {
        //reload active scene(easy way to retrigger lock checks)     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Start()
    {

        //check location variables
        if (briefing == true) { briefingLoadEvents(); }
        else if (fitting == true) { fittingLoadEvents(); }
        else if (hangar == true) { swapint = ObserverScript.Instance.esSwap; hangarEvents(); }
        //clear text box
        speechBox.text = " ";
    }
    private void Update()
    {
        if (slider.transform.position.y>=endPoint.transform.position.y)
        {
            //stop movement
            slider.GetComponent<Rigidbody2D>().velocity = new Vector2(slider.GetComponent<Rigidbody2D>().velocity.x, 0);
            //start typeing
            StartCoroutine(TypeText());
        }
    }
}
