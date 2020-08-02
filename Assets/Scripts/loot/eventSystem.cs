using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class eventSystem : MonoBehaviour
{
    public SpriteRenderer cSpeaker;
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
    sceneManager sm;
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
        else if (ObserverScript.Instance.levelsCleared < 0) {/*do nothing*/}
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
                        sm.hangar();
                    }
                    else if (unlocks[26] == false)
                    {
                        ObserverScript.Instance.esSwap = 2;
                        swapBool = true;
                        sm.hangar();
                    }
                    else if (unlocks[27] == false)
                    {
                        ObserverScript.Instance.esSwap = 3;
                        swapBool = true;
                        sm.hangar();
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
                        sm.hangar();
                    }
                    else if (unlocks[35] == false) 
                    {
                        //set esSwap to handoff info to 'hangar' scene
                        ObserverScript.Instance.esSwap = 5;
                        //tell loop it is done incase script still runs after ecene change somehow
                        swapBool = true;
                        //change scene
                        sm.hangar();
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
        if (swapint == 0) { sm.briefing(); Debug.Log("error: no value sent to hangar"); }
        else if (swapint == 1) { msgselect = 0; eventLingth = 6; eventStart(); }
        else if (swapint == 2) { msgselect = 7; eventLingth = 13; eventStart(); }
        else if (swapint == 3) { msgselect = 14; eventLingth = 20; eventStart(); }
        else if (swapint == 3) { msgselect = 21; eventLingth = 27; eventStart(); }
        else if (swapint == 3) { msgselect = 28; eventLingth = 34; eventStart(); }
    }
    //corrently just for refrence---------------
    public void missileUnlock1()
    {
        if (msgselect == 0) { }//request
        //if (msgselect == 1) { } responce 1 (should never be true) "yes"
        //if (msgselect == 2) { } responce 2 (should never be true) "no"
        //if (msgselect == 3) { } additional "no" (for an are you shure)
        if (msgselect == 4) { }//are you shure?
        if (msgselect == 5) { }//thanks (end event and incroment event)
        if (msgselect == 6) { }//thanks... for nothing(end event no incroment)
    }
    public void missileUnlock2()
    {
        if (msgselect == 7) { }
        //if (msgselect == 8) { }
        //if (msgselect == 9) { }
        //if (msgselect == 10) { }
        if (msgselect == 11) { }
        if (msgselect == 12) { }
        if (msgselect == 13) { }
    }
    public void missileUnlock3()
    {
        if (msgselect == 14) { }
        //if (msgselect == 15) { }
        //if (msgselect == 16) { }
        //if (msgselect == 17) { }
        if (msgselect == 18) { }
        if (msgselect == 19) { }
        if (msgselect == 20) { }
    }
    public void shipUnlock1Part1()
    {
        if (msgselect == 21) { }
        //if (msgselect == 22) { }
        //if (msgselect == 23) { }
        //if (msgselect == 24) { }
        if (msgselect == 25) { }
        if (msgselect == 26) { }
        if (msgselect == 27) { }
    }
    public void shipUnlock1Part2()
    {
        if (msgselect == 0) { }
        //if (msgselect == 1) { }
        //if (msgselect == 2) { }
        //if (msgselect == 3) { }
        if (msgselect == 4) { }
        if (msgselect == 5) { }
        if (msgselect == 6) { }
    }
    public void shipUnlock2Part1()
    {
        if (msgselect == 28) { }
        //if (msgselect == 29) { }
        //if (msgselect == 30) { }
        //if (msgselect == 31) { }
        if (msgselect == 32) { }
        if (msgselect == 33) { }
        if (msgselect == 34) { }
    }
    public void shipUnlock2Part2()
    {
        if (msgselect == 7) { }
        //if (msgselect == 8) { }
        //if (msgselect == 9) { }
        //if (msgselect == 10) { }
        if (msgselect == 11) { }
        if (msgselect == 12) { }
        if (msgselect == 13) { }
    }
    //--------------end refrence
    IEnumerator TypeText()
    {
        //make skip btn interactable 
        if (hangar == true) { btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
        //tell button loop is running
        typeing = true;
        //clear text box
        speechBox.text = "";
        //l00p to fil in the text box letter by letter
        foreach (char letter in message[msgselect].ToCharArray())
        {
            //if text box filled in skip.
            if (speechBox.text == message[msgselect]) 
            { break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break; break;}
            //type a letter
            speechBox.text += letter;
            //wait
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        //set responce btns
        if (hangar == true) 
        {
            if (msgselect == 0) { btn1Txt.text = message[1]; btn2Txt.text = message[2]; }
            else if (msgselect == 3) { btn1Txt.text = message[1]; btn2Txt.text = message[3]; }

            else if (msgselect == 7) { btn1Txt.text = message[8]; btn2Txt.text = message[9]; }
            else if (msgselect == 11) { btn1Txt.text = message[8]; btn2Txt.text = message[10]; }

            else if (msgselect == 14) { btn1Txt.text = message[15]; btn2Txt.text = message[16]; }
            else if (msgselect == 18) { btn1Txt.text = message[15]; btn2Txt.text = message[17]; }

            else if (msgselect == 21) { btn1Txt.text = message[22]; btn2Txt.text = message[23]; }
            else if (msgselect == 25) { btn1Txt.text = message[22]; btn2Txt.text = message[24]; }

            else if (msgselect == 28) { btn1Txt.text = message[29]; btn2Txt.text = message[30]; }
            else if (msgselect == 34) { btn1Txt.text = message[29]; btn2Txt.text = message[31]; }
            //clear skip btn from being interactable
            if (msgselect != 5 || msgselect != 6 || msgselect != 12 || msgselect != 13 || msgselect != 19 || msgselect != 20 || msgselect != 26 || msgselect != 27 || msgselect != 33 || msgselect != 34)
            {
                btn.GetComponent<CanvasGroup>().interactable = false;
                btn.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
        //tell button loop is over
        typeing = false;
    }
    public void selection1() 
    {//yes
        if (typeing == true)
        {
            //hopefully bypass the text box fill in
            speechBox.text = message[msgselect];
        }
        else if (typeing == false) 
        {
            //missile1
            if (msgselect == 0) { msgselect = 5; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            else if (msgselect==3) { msgselect = 5; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            //missile2
            else if (msgselect == 7) { msgselect = 12; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            else if (msgselect == 11) { msgselect = 12; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            //missile3
            else if (msgselect == 14) { msgselect = 19; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            else if (msgselect == 18) { msgselect = 19; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            //ship1
            else if (msgselect == 21) { msgselect = 26; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            else if (msgselect == 25) { msgselect = 26; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            //ship2
            else if (msgselect == 28) { msgselect = 33; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            else if (msgselect == 34) { msgselect = 33; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            btn1Txt.text = ("");
            btn2Txt.text = ("");
        }
    }
    public void selection2()
    {//no
        if (typeing == true)
        {
            //hopefully bypass the text box fill in
            speechBox.text = message[msgselect];
        }
        else if (typeing == false)
        {
            //missile1
            if (msgselect == 0) { msgselect = 4; StartCoroutine(TypeText()); }
            else if (msgselect == 3) { msgselect = 6; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            //missile2
            else if (msgselect == 7) { msgselect = 11; StartCoroutine(TypeText()); }
            else if (msgselect == 11) { msgselect = 13; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            //missile3
            else if (msgselect == 14) { msgselect = 18; StartCoroutine(TypeText()); }
            else if (msgselect == 18) { msgselect = 20; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            //ship1
            else if (msgselect == 21) { msgselect = 25; StartCoroutine(TypeText()); }
            else if (msgselect == 25) { msgselect = 27; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
            //ship2
            else if (msgselect == 28) { msgselect = 32; StartCoroutine(TypeText()); }
            else if (msgselect == 32) { msgselect = 34; StartCoroutine(TypeText()); btn.GetComponent<CanvasGroup>().interactable = true; btn.GetComponent<CanvasGroup>().blocksRaycasts = true; }
        }

        btn1Txt.text = ("");
        btn2Txt.text = ("");
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
            if (typeing == false) 
            {
                if (msgselect == 5 || msgselect == 6 || msgselect == 12 || msgselect == 13 || msgselect == 19 || msgselect == 20 || msgselect == 26 || msgselect == 27 || msgselect == 33 || msgselect == 34)
                {
                    sm.Invoke(ObserverScript.Instance.missionType , 0);
                    Debug.Log("attempted to leave");
                }
            }
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
        //start typeing
        StartCoroutine(TypeText());
        btn1Txt.text = ("");
        btn2Txt.text = ("");
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
        else if (hangar == true) {btn1Txt.text=(" "); btn2Txt.text = (" "); swapint = ObserverScript.Instance.esSwap; hangarEvents(); }
        //clear text box
        speechBox.text = " ";
        sm = FindObjectOfType<sceneManager>();
    }
    private void Update()
    {
        if (slider.transform.position.y>=endPoint.transform.position.y)
        {
            //stop movement
            slider.GetComponent<Rigidbody2D>().velocity = new Vector2(slider.GetComponent<Rigidbody2D>().velocity.x, 0);
        }
    }
}
