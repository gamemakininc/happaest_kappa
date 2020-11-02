using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class eventSystem : MonoBehaviour
{
    public GameObject wrningScreen;
    public SpriteRenderer cSpeaker;
    public Text btn1Txt;
    public Text btn2Txt;
    public Sprite[] speakers;
    // 0=h 1=s 2=v
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
        //unlock ship
        if (eventTriedFitting == true) {/*do nothing*/ }
        else if (ObserverScript.Instance.shipswap<=ObserverScript.Instance.levelsCleared) //check if ship ready to unlock
        {
            //add to next ship unlock timer
            if (ObserverScript.Instance.diff == 0) {ObserverScript.Instance.shipswap += 5; }
            else if (ObserverScript.Instance.diff == 1) { ObserverScript.Instance.shipswap += 5; }
            else if (ObserverScript.Instance.diff == 2) { ObserverScript.Instance.shipswap += 10; }
            else if (ObserverScript.Instance.diff == 3) { ObserverScript.Instance.shipswap += Random.Range(20,30); }
            //unlock a ship
            if (unlocks[28] == false) {ObserverScript.Instance.unlocks[28] = true;}
            else if (unlocks[29] == false) {ObserverScript.Instance.unlocks[29] = true;}
            else if (unlocks[30] == false) {ObserverScript.Instance.unlocks[30] = true;}
            else if (unlocks[31] == false) {ObserverScript.Instance.unlocks[31] = true;}
            else if (unlocks[32] == false) {ObserverScript.Instance.unlocks[32] = true;}
            else if (unlocks[33] == false) {ObserverScript.Instance.unlocks[33] = true;}
        }
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
                while (swapBool == false)
                {
                    //set rng
                    swapint = Random.Range(0, 8);
                    //unlock something (hopefully)
                    Debug.Log( "unlock tried " + swapint);
                    if (swapint == 0)
                    {
                        if (unlocks[1] == false && swapBool == false)
                        {
                            //note 0h 1s 2v appearence of v should be considered a mission NPC
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            //unlock low tier item
                            ObserverScript.Instance.unlocks[1] = true;
                            //set event trigger
                            eventAllreadyTriggered = true;
                            //set notifacation message
                            msgselect = 0;
                            eventLingth = 1;
                            //display notifacation message
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 1;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[2] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            //unlock mid tier item
                            ObserverScript.Instance.unlocks[2] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 2;
                            eventLingth = 3;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 2;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[3] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            //unlock high tier item
                            ObserverScript.Instance.unlocks[3] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 4;
                            eventLingth = 5;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 3;
                            //stop the loop
                            swapBool = true;
                        }
                    }
                    else if (swapint == 1)
                    {
                        if (unlocks[4] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[4] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 6;
                            eventLingth = 7;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 4;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[5] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[5] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 8;
                            eventLingth = 9;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 5;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[6] == false && swapBool == false)
                        {

                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[6] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 10;
                            eventLingth = 11;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 6;
                            //stop the loop
                            swapBool = true;
                        }
                    }
                    else if (swapint == 2)
                    {
                        if (unlocks[7] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[7] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 12;
                            eventLingth = 13;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 7;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[8] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[8] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 14;
                            eventLingth = 15;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 8;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[9] == false && swapBool == false)
                        {

                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[9] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 16;
                            eventLingth = 17;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 9;
                            //stop the loop
                            swapBool = true;
                        }
                    }
                    else if (swapint == 3)
                    {
                        if (unlocks[10] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[10] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 18;
                            eventLingth = 19;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 10;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[11] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[11] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 20;
                            eventLingth = 21;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 11;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[12] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[1];
                            ObserverScript.Instance.unlocks[12] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 22;
                            eventLingth = 23;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 12;
                            //stop the loop
                            swapBool = true;
                        }
                    }
                    else if (swapint == 4)
                    {
                        if (unlocks[13] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[13] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 24;
                            eventLingth = 25;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 13;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[14] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[14] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 26;
                            eventLingth = 27;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 14;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[15] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[15] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 28;
                            eventLingth = 29;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 15;
                            //stop the loop
                            swapBool = true;
                        }
                    }
                    else if (swapint == 5)
                    {
                        if (unlocks[16] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[16] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 30;
                            eventLingth = 31;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 16;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[17] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[17] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 32;
                            eventLingth = 33;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 17;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[18] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[18] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 34;
                            eventLingth = 35;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 18;
                            //stop the loop
                            swapBool = true;
                        }
                    }
                    else if (swapint == 6)
                    {
                        if (unlocks[19] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[19] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 36;
                            eventLingth = 37;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 19;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[20] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[20] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 38;
                            eventLingth = 39;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 20;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[21] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[21] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 40;
                            eventLingth = 41;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 21;
                            //stop the loop
                            swapBool = true;
                        }
                    }
                    else if (swapint == 7)
                    {
                        if (unlocks[22] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[22] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 42;
                            eventLingth = 43;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 22;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[23] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[23] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 44;
                            eventLingth = 45;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 23;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[24] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[0];
                            ObserverScript.Instance.unlocks[24] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 46;
                            eventLingth = 47;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 24;
                            //stop the loop
                            swapBool = true;
                        }
                    }
                    else if (swapint == 8)
                    {
                        if (unlocks[25] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[2];
                            ObserverScript.Instance.unlocks[25] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 48;
                            eventLingth = 49;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 25;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[26] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[2];
                            ObserverScript.Instance.unlocks[26] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 50;
                            eventLingth = 51;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 26;
                            //stop the loop
                            swapBool = true;
                        }
                        else if (unlocks[27] == false && swapBool == false)
                        {
                            //set who is speaking
                            cSpeaker.sprite = speakers[2];
                            ObserverScript.Instance.unlocks[27] = true;
                            eventAllreadyTriggered = true;
                            msgselect = 52;
                            eventLingth = 53;
                            eventStart();
                            //set swapint to unlocked item
                            swapint = 27;
                            //stop the loop
                            swapBool = true;
                        }
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
                swapint = Random.Range(0,8);
                //unlock something (hopefully)
                Debug.Log("unlock tried " + swapint);
                if (swapint == 0) 
                {
                    if (unlocks[1] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        //unlock low tier item
                        ObserverScript.Instance.unlocks[1] = true;
                        //set event trigger
                        eventAllreadyTriggered = true;
                        //set notifacation message
                        msgselect = 0;
                        eventLingth = 1;
                        //display notifacation message
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 1;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[2] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        //unlock mid tier item
                        ObserverScript.Instance.unlocks[2] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 2;
                        eventLingth = 3;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 2;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[3] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        //unlovk high tier item
                        ObserverScript.Instance.unlocks[3] = true;
                        eventAllreadyTriggered = true; 
                        msgselect = 4;
                        eventLingth = 5;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 3;
                        //stop the loop
                        swapBool = true;
                    }
                }
                else if (swapint == 1) 
                {
                    if (unlocks[4] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[4] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 6;
                        eventLingth = 7;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 4;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[5] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[5] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 8;
                        eventLingth = 9;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 5;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[6] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[6] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 10;
                        eventLingth = 11;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 6;
                        //stop the loop
                        swapBool = true;
                    }
                }
                else if (swapint == 2)
                {
                    if (unlocks[7] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[7] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 12;
                        eventLingth = 13;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 7;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[8] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[8] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 14;
                        eventLingth = 15;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 8;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[9] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[9] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 16;
                        eventLingth = 17;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 9;
                        //stop the loop
                        swapBool = true;
                    }
                }
                else if (swapint == 3)
                {
                    if (unlocks[10] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[10] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 18;
                        eventLingth = 19;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 10;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[11] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[11] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 20;
                        eventLingth = 21;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 11;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[12] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[1];
                        ObserverScript.Instance.unlocks[12] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 22;
                        eventLingth = 23;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 12;
                        //stop the loop
                        swapBool = true;
                    }
                }
                else if (swapint == 4)
                {
                    if (unlocks[13] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[13] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 24;
                        eventLingth = 25;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 13;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[14] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[14] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 26;
                        eventLingth = 27;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 14;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[15] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[15] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 28;
                        eventLingth = 29;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 15;
                        //stop the loop
                        swapBool = true;
                    }
                }
                else if (swapint == 5)
                {
                    if (unlocks[16] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[16] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 30;
                        eventLingth = 31;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 16;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[17] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[17] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 32;
                        eventLingth = 33;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 17;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[18] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[18] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 34;
                        eventLingth = 35;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 18;
                        //stop the loop
                        swapBool = true;
                    }
                }
                else if (swapint == 6)
                {
                    if (unlocks[19] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[19] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 36;
                        eventLingth = 37;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 19;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[20] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[20] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 38;
                        eventLingth = 39;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 20;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[21] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[21] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 40;
                        eventLingth = 41;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 21;
                        //stop the loop
                        swapBool = true;
                    }
                }
                else if (swapint == 7)
                {
                    if (unlocks[22] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[22] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 42;
                        eventLingth = 43;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 22;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[23] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[23] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 44;
                        eventLingth = 45;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 23;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[24] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[0];
                        ObserverScript.Instance.unlocks[24] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 46;
                        eventLingth = 47;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 24;
                        //stop the loop
                        swapBool = true;
                    }
                }
                else if (swapint == 8)
                {
                    if (unlocks[25] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[2];
                        ObserverScript.Instance.unlocks[25] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 48;
                        eventLingth = 49;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 25;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[26] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[2];
                        ObserverScript.Instance.unlocks[26] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 50;
                        eventLingth = 51;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 26;
                        //stop the loop
                        swapBool = true;
                    }
                    else if (unlocks[27] == false && swapBool == false)
                    {
                        //set who is speaking
                        cSpeaker.sprite = speakers[2];
                        ObserverScript.Instance.unlocks[27] = true;
                        eventAllreadyTriggered = true;
                        msgselect = 52;
                        eventLingth = 53;
                        eventStart();
                        //set swapint to unlocked item
                        swapint = 27;
                        //stop the loop
                        swapBool = true;
                    }
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
    //unlock missiles than questline ships
    {

        eventTriedInterrupt = ObserverScript.Instance.bookmark3;
        eventAllreadyTriggered = ObserverScript.Instance.bookmark0;
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //bypass checks if questline ready to progress
        if (ObserverScript.Instance.mProgressShip == 2 || ObserverScript.Instance.mProgressShip == 6 || ObserverScript.Instance.mProgressShip == 8 || ObserverScript.Instance.mProgressShip == 10)
        {
            //witch inbetween state is it
            if (ObserverScript.Instance.mProgressShip == 2)
            {//s1p2 ready to trigger
                //set constant swap var
                ObserverScript.Instance.esSwap = 6;
                //change scene
                sm.hangar();
            }
            else if (ObserverScript.Instance.mProgressShip == 6)
            {//s2p2 ready to trigger
                //set constant swap var
                ObserverScript.Instance.esSwap = 8;
                //change scene
                sm.hangar();
            }
            else if (ObserverScript.Instance.mProgressShip == 8)
            {//s2p3 ready to trigger
                //set constant swap var
                ObserverScript.Instance.esSwap = 9;
                //change scene
                sm.hangar();
            }
            else if (ObserverScript.Instance.mProgressShip == 10)
            {//s2p4 ready to trigger
                //set constant swap var
                ObserverScript.Instance.esSwap = 10;
                //change scene
                sm.hangar();
            }

        }
        //check for event elegitability
        else if (eventTriedInterrupt == true) {/*start mission*/ }
        else if (ObserverScript.Instance.levelsCleared > 15) {/*start mission*/ }
        //poll RNG
        else if (swapint <= 20)
        {
            //this should not be neccicary
            ObserverScript.Instance.bookmark0 = true;
            //check if any missiles can unlock
            if (unlocks[25] == false || unlocks[26] == false || unlocks[27] == false)
            {
                //check lowest grade
                if (unlocks[25] == false && ObserverScript.Instance.mProgressMissile < 1)
                {
                    swapBool = true;
                    //set observer script var to tell hangar to start missile 1 mission
                    ObserverScript.Instance.esSwap = 1;
                    //set swapint (for debug)
                    swapint = 25;
                }
                //if allready unlocked check med grade 
                else if (unlocks[26] == false && ObserverScript.Instance.mProgressMissile == 3)
                {
                    swapBool = true;
                    //set observer script var to tell hangar to start missile 2 mission
                    ObserverScript.Instance.esSwap = 3;
                    //set swapint (for debug)
                    swapint = 26;

                }
                //if prievious 2 unlocked try high grade
                else if (unlocks[27] == false && ObserverScript.Instance.mProgressMissile == 5)
                {
                    swapBool = true;
                    //set observer script var to tell hangar to start missile 3 mission
                    ObserverScript.Instance.esSwap = 4;
                    //set swapint (for debug)
                    swapint = 27;

                }
            }
            //if all missiles unlocked reroll RNG for secrit ships
            else
            {
                //reset counters
                counter = 0;
                swapint = 0;
                //loop to check state of unlocks
                while (counter < 37)
                {
                    if (unlocks[counter] == true)
                    {
                        //every unlocked item incriment swap
                        swapint++;
                    }
                    //increment counter
                    counter++;
                }
                //check avalibility (if 20 total unlocks aquired)
                if (swapint > 20)
                {
                    //reset RNG
                    swapint = Random.Range(1, 100);
                    //poll RNG
                    if (swapint <= 20 && ObserverScript.Instance.mProgressShip == 0)
                    {
                        swapBool = true;
                        //set observer script var to tell hangar to start ship1 mission
                        ObserverScript.Instance.esSwap = 5;
                        //Note reserve 6 for callback from end mission
                    }
                    else if (swapint <= 10 && ObserverScript.Instance.mProgressShip == 5)
                    {
                        swapBool = true;
                        //set observer script var to tell hangar to start ship1 mission
                        ObserverScript.Instance.esSwap = 7;
                        //Note 8,9,10 are used for mission steps
                    }
                }


            }
            if (swapBool == true) { Debug.Log("unlocked" + swapint); }

        }
        if (swapBool == true)
        {//if something triggered go to hangar interrupt scene
            sm.hangar();
        }
        else 
        {//if nothing triggered go to mission
            sm.gameplay(); 
        }
        //idk why i am doing this but i am...
        eventTriedInterrupt = true;
        ObserverScript.Instance.bookmark3 = true;
    }
    public void hangarEvents()
    {
        switch (swapint)
        {
            case 0://nothing sent
                sm.briefing(); Debug.Log("error: no value sent to hangar");
                break;
            case 1://missile1
                //set starting msg
                msgselect = 0;
                //send to appropriate function
                missileUnlock1();
                break;
            case 2://missile2
                //set starting msg
                msgselect = 7;
                //send to appropriate function
                m1unlockfailed();
                break;
            case 3://missile3
                //set starting msg
                msgselect = 11;
                //send to appropriate function
                missileUnlock2();
                break;
            case 4://ship1p1
                //set starting msg
                msgselect = 18;
                //send to appropriate function
                missileUnlock3();
                break;
            case 5://ship1p2
                //set starting msg
                msgselect = 25;
                //send to appropriate function
                s1Phase1();
                break;
            case 6:
                //set starting msg
                msgselect = 32;
                //send to appropriate function
                s1Phase2();
                break;
            case 7:
                //set starting msg
                msgselect = 39;
                //send to appropriate function
                s2Phase1();
                break;
            case 8:
                //set starting msg
                msgselect = 46;
                //send to appropriate function
                s2Phase2();
                break;
            case 9:
                //set starting msg
                msgselect = 53;
                //send to appropriate function
                s2Phase3();
                break;
            case 10:
                //set starting msg
                msgselect = 60;
                //send to appropriate function
                s2Phase4();
                break;
        }

    }
    void missileUnlock1()
    {
        if (msgselect == 0) 
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 6;
            //start typeing
            eventStart();
        }//print message 'request'
        else if (msgselect == 1) { msgselect = 5; } //redirect you said 'yes'
        else if (msgselect == 2) { msgselect = 4; } //redirect you said 'no'
        else if (msgselect == 3) { msgselect = 6; } //redirect said 'no' again
        if (msgselect == 4) { StartCoroutine(TypeText()); } //are you shure?(responce to first no)
        else if (msgselect == 5)
        {
            ObserverScript.Instance.mProgressMissile++;
            StartCoroutine(TypeText()); 
        } //thanks (end event and incroment event tracker)
        else if (msgselect == 6) { StartCoroutine(TypeText()); } //thanks... for nothing (end event no incroment)
    }
    void m1unlockfailed()
    {
        
        if (msgselect == 7)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[0];
            //set ending msg
            eventLingth = 10;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 8) { msgselect = 10; }// responce 1 "yes"
        else if (msgselect == 9) { msgselect = 10; }// responce 2 "no" 
        if (msgselect == 10)
        {
            ObserverScript.Instance.mProgressMissile=0;
            StartCoroutine(TypeText()); 
        }//there was an explosion.(mission progress reset)
    }
    void missileUnlock2()
    {
        if (msgselect == 11)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 17;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 12) { msgselect = 16; }//redirect you said 'yes'
        else if (msgselect == 13) { msgselect = 15; }//redirect you said 'no'
        else if (msgselect == 14) { msgselect = 17; }//redirect said 'no' again
        if (msgselect == 15) { StartCoroutine(TypeText()); }//are you shure?(responce to first no)
        else if (msgselect == 16)
        {
            ObserverScript.Instance.mProgressMissile++;
            StartCoroutine(TypeText()); 
        }//thanks (end event and incroment event tracker)
        else if (msgselect == 17) { StartCoroutine(TypeText()); 
        }//thanks... for nothing (end event no incroment)
    }
    void missileUnlock3()
    {
        if (msgselect == 18)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 24;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 19) { msgselect = 23; }//redirect you said 'yes'
        else if (msgselect == 20) { msgselect = 22; }//redirect you said 'no'
        else if (msgselect == 21) { msgselect = 27; }//redirect said 'no' again
        if (msgselect == 22) { StartCoroutine(TypeText()); }//are you shure?(responce to first no)
        else if (msgselect == 23)
        {
            ObserverScript.Instance.mProgressMissile++;
            StartCoroutine(TypeText()); 
        }//thanks (end event and incroment event tracker)
        else if (msgselect == 24) { StartCoroutine(TypeText());}//thanks... for nothing (end event no incroment)
    }
    void s1Phase1()
    {
        if (msgselect == 25)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 31;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 26) { msgselect = 30; }//redirect you said 'yes'
        else if (msgselect == 27) { msgselect = 29; }//redirect you said 'no'
        else if (msgselect == 28) { msgselect = 31; }//redirect said 'no' again
        if (msgselect == 29) { StartCoroutine(TypeText()); }//are you shure?(responce to first no)
        else if (msgselect == 30)
        {
            ObserverScript.Instance.mProgressShip++;
            StartCoroutine(TypeText()); 
        }//thanks (end event and incroment event tracker)
        else if (msgselect == 31) { StartCoroutine(TypeText()); }//thanks... for nothing (end event no incroment)
    }
    void s1Phase2()
    {
        if (msgselect == 32)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 38;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 33) { msgselect = 37; }//redirect you said 'yes'
        else if (msgselect == 34) { msgselect = 36; }//redirect you said 'no'
        else if (msgselect == 35) { msgselect = 38; }//redirect said 'no' again
        if (msgselect == 36) { StartCoroutine(TypeText()); }//are you shure?(responce to first no)
        else if (msgselect == 37)
        {
            ObserverScript.Instance.mProgressShip++;
            StartCoroutine(TypeText()); 
        }//thanks (end event and incroment event tracker)
        else if (msgselect == 38) { StartCoroutine(TypeText()); }//thanks... for nothing (end event no incroment)
    }
    void s2Phase1()
    {
        if (msgselect == 39)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 45;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 40) { msgselect = 44; }//redirect you said 'yes'
        else if (msgselect == 41) { msgselect = 43; }//redirect you said 'no'
        else if (msgselect == 42) { msgselect = 45; }//redirect said 'no' again
        if (msgselect == 43) { StartCoroutine(TypeText()); }//are you shure?(responce to first no)
        else if (msgselect == 44)
        {
            ObserverScript.Instance.mProgressShip++;
            StartCoroutine(TypeText()); 
        }//thanks (end event and incroment event tracker)
        else if (msgselect == 45) { StartCoroutine(TypeText()); }//thanks... for nothing (end event no incroment)
    }
    void s2Phase2()
    {
        if (msgselect == 46)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 52;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 47) { msgselect = 51; }//redirect you said 'yes'
        else if (msgselect == 48) { msgselect = 50; }//redirect you said 'no'
        else if (msgselect == 49) { msgselect = 52; }//redirect said 'no' again
        if (msgselect == 50) { StartCoroutine(TypeText()); }//are you shure?(responce to first no)
        else if (msgselect == 51)
        {
            ObserverScript.Instance.mProgressShip++;
            StartCoroutine(TypeText()); 
        }//thanks (end event and incroment event tracker)
        else if (msgselect == 52) { StartCoroutine(TypeText()); }//thanks... for nothing (end event no incroment)
    }
    void s2Phase3()
    {
        if (msgselect == 53)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 59;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 54) { msgselect = 58; }//redirect you said 'yes'
        else if (msgselect == 55) { msgselect = 57; }//redirect you said 'no'
        else if (msgselect == 56) { msgselect = 59; }//redirect said 'no' again
        if (msgselect == 57) { StartCoroutine(TypeText()); }//are you shure?(responce to first no)
        else if (msgselect == 58)
        {
            ObserverScript.Instance.mProgressShip++;
            StartCoroutine(TypeText()); 
        }//thanks (end event and incroment event tracker)
        else if (msgselect == 59) { StartCoroutine(TypeText()); }//thanks... for nothing (end event no incroment)
    }
    void s2Phase4()
    {
        if (msgselect == 60)
        {
            //set speaker sprite
            cSpeaker.sprite = speakers[2];
            //set ending msg
            eventLingth = 66;
            //start event
            eventStart();
        }//print message 'request'
        else if (msgselect == 61) { msgselect = 65; }//redirect you said 'yes'
        else if (msgselect == 62) { msgselect = 64; }//redirect you said 'no'
        else if (msgselect == 63) { msgselect = 66; }//redirect said 'no' again
        if (msgselect == 64) { StartCoroutine(TypeText()); }//are you shure?(responce to first no)
        else if (msgselect == 65) 
        {
            ObserverScript.Instance.mProgressShip++;
            StartCoroutine(TypeText()); 
        }//thanks (end event and incroment event tracker)
        else if (msgselect == 66) {StartCoroutine(TypeText()); }//thanks... for nothing (end event no incroment)
    }
    IEnumerator TypeText()
    {
        //make skip btn interactable 
        if (hangar == true) 
        { 
            btn.GetComponent<CanvasGroup>().interactable = true; 
            btn.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        //tell button loop is running
        typeing = true;
        //clear text box
        speechBox.text = "";
        //l00p to fil in the text box letter by letter
        foreach (char letter in message[msgselect].ToCharArray())
        {
            //if text box filled in skip.
            if (speechBox.text == message[msgselect]) 
            { break;}
            //type a letter
            speechBox.text += letter;
            //wait
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        //set responce btns
        if (hangar == true) 
        {//where are we
            //m1
            if (msgselect == 0) { btn1Txt.text = message[1]; btn2Txt.text = message[2]; }
            else if (msgselect == 4) { btn1Txt.text = message[1]; btn2Txt.text = message[3]; }
            //m1 fail
            else if (msgselect == 7) { btn1Txt.text = message[8]; btn2Txt.text = message[9]; }
            //m2
            else if (msgselect == 11) { btn1Txt.text = message[12]; btn2Txt.text = message[13]; }
            else if (msgselect == 15) { btn1Txt.text = message[12]; btn2Txt.text = message[14]; }
            //m3
            else if (msgselect == 18) { btn1Txt.text = message[19]; btn2Txt.text = message[20]; }
            else if (msgselect == 22) { btn1Txt.text = message[19]; btn2Txt.text = message[21]; }
            //ss1p1
            else if (msgselect == 25) { btn1Txt.text = message[26]; btn2Txt.text = message[27]; }
            else if (msgselect == 29) { btn1Txt.text = message[26]; btn2Txt.text = message[28]; }
            //ss1p2
            else if (msgselect == 32) { btn1Txt.text = message[33]; btn2Txt.text = message[34]; }
            else if (msgselect == 36) { btn1Txt.text = message[33]; btn2Txt.text = message[35]; }
            //ss2p1
            else if (msgselect == 39) { btn1Txt.text = message[40]; btn2Txt.text = message[41]; }
            else if (msgselect == 43) { btn1Txt.text = message[40]; btn2Txt.text = message[42]; }
            //ss2p2
            else if (msgselect == 46) { btn1Txt.text = message[47]; btn2Txt.text = message[48]; }
            else if (msgselect == 50) { btn1Txt.text = message[47]; btn2Txt.text = message[49]; }
            //ss2p3
            else if (msgselect == 53) { btn1Txt.text = message[54]; btn2Txt.text = message[55]; }
            else if (msgselect == 57) { btn1Txt.text = message[54]; btn2Txt.text = message[56]; }
            //ss2p4
            else if (msgselect == 60) { btn1Txt.text = message[61]; btn2Txt.text = message[62]; }
            else if (msgselect == 64) { btn1Txt.text = message[61]; btn2Txt.text = message[63]; }
            //clear skip btn from being interactable
            if (msgselect == 5|| msgselect == 6 || msgselect ==10 || msgselect == 16 || msgselect == 17 || msgselect == 23 || msgselect == 24 || msgselect == 30 || msgselect == 31 || msgselect == 37 || msgselect == 38 || msgselect == 44 || msgselect == 45 || msgselect == 51 || msgselect == 52 || msgselect == 58 || msgselect == 59 || msgselect == 65 || msgselect == 66)
            {
                //if in end state do not dissable btn
            }
            else
            {
                //dissable btn
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
            //m1
            if (msgselect == 0) { msgselect = 5; missileUnlock1(); }
            else if (msgselect == 4) { msgselect = 5; missileUnlock1(); }
            //m1fail
            else if (msgselect == 4) { msgselect = 5; m1unlockfailed(); }
            //m2
            if (msgselect == 11) { msgselect = 16; missileUnlock2(); }
            else if (msgselect == 15) { msgselect = 16; missileUnlock2(); }
            //m3
            if (msgselect == 18) { msgselect = 23; missileUnlock3(); }
            else if (msgselect == 22) { msgselect = 23; missileUnlock3(); }
            //ss1p1
            if (msgselect == 25) { msgselect = 30; s1Phase1(); }
            else if (msgselect == 29) { msgselect = 30; s1Phase1(); }
            //ss1p2
            if (msgselect == 32) { msgselect = 37; s1Phase2(); }
            else if (msgselect == 36) { msgselect = 37; s1Phase2(); }
            //ss2p1
            if (msgselect == 39) { msgselect = 44; s2Phase2(); }
            else if (msgselect == 43) { msgselect = 44; s2Phase2(); }
            //ss2p2
            if (msgselect == 46) { msgselect = 51; s2Phase2(); }
            else if (msgselect == 50) { msgselect = 51; s2Phase2(); }
            //ss2p3
            if (msgselect == 53) { msgselect = 58; s2Phase3(); }
            else if (msgselect == 57) { msgselect = 58; s2Phase3(); }
            //ss2p4
            if (msgselect == 60) { msgselect = 65; s2Phase4(); }
            else if (msgselect == 64) { msgselect = 65; s2Phase4(); }

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
            //m1
            if (msgselect == 0) { msgselect = 4; missileUnlock1(); }
            else if (msgselect == 4) { msgselect = 6; missileUnlock1(); }
            //m1fail
            else if (msgselect == 4) { msgselect = 10; m1unlockfailed(); }
            //m2
            if (msgselect == 11) { msgselect = 15; missileUnlock2(); }
            else if (msgselect == 15) { msgselect = 17; missileUnlock2(); }
            //m3
            if (msgselect == 18) { msgselect = 22; missileUnlock3(); }
            else if (msgselect == 22) { msgselect = 24; missileUnlock3(); }
            //ss1p1
            if (msgselect == 25) { msgselect = 29; s1Phase1(); }
            else if (msgselect == 29) { msgselect = 31; s1Phase1(); }
            //ss1p2
            if (msgselect == 32) { msgselect = 36; s1Phase2(); }
            else if (msgselect == 36) { msgselect = 38; s1Phase2(); }
            //ss2p1
            if (msgselect == 39) { msgselect = 43; s2Phase1(); }
            else if (msgselect == 43) { msgselect = 45; s2Phase1(); }
            //ss2p2
            if (msgselect == 46) { msgselect = 50; s2Phase2(); }
            else if (msgselect == 50) { msgselect = 52; s2Phase2(); }
            //ss2p3
            if (msgselect == 53) { msgselect = 57; s2Phase3(); }
            else if (msgselect == 57) { msgselect = 59; s2Phase3(); }
            //ss2p4
            if (msgselect == 60) { msgselect = 64; s2Phase4(); }
            else if (msgselect == 64) { msgselect = 66; s2Phase4(); }
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
                //reset variable that this scene uses
                ObserverScript.Instance.esSwap = 0;
                //start mission(this should only be accessable after dialogue ends)
                sm.gameplay();
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
        if (hangar == true)
        {
            btn1Txt.text = ("");
            btn2Txt.text = ("");
            speechBox.text = ("");
        }
        //start typeing
        StartCoroutine(TypeText());
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
        else if (hangar == true) 
        {
            btn1Txt.text=(" "); btn2Txt.text = (" "); 
            swapint = ObserverScript.Instance.esSwap;
            hangarEvents(); 
        }
        //clear text box
        speechBox.text = " ";
        sm = FindObjectOfType<sceneManager>();
        //check if faction change is ready to trigger
        if (ObserverScript.Instance.factionRangeSwap <= ObserverScript.Instance.levelsCleared)
        {
            ObserverScript.Instance.defenceMission = true;
            //dependant on faction id set level type
            if (ObserverScript.Instance.factionId == 0) { ObserverScript.Instance.missionType = 0; }
            else if (ObserverScript.Instance.factionId == 1) { ObserverScript.Instance.missionType = 1; }
            else  { ObserverScript.Instance.missionType = Random.Range(0,1); }
            //update factionId
            ObserverScript.Instance.factionChange();
            //launch mission
            sm.gameplay();
        }
    }
    bool fade;
    float F = 0;
    private void Update()
    {
        
        if (slider.transform.position.y>=endPoint.transform.position.y)
        {
            //stop movement
            slider.GetComponent<Rigidbody2D>().velocity = new Vector2(slider.GetComponent<Rigidbody2D>().velocity.x, 0);
        }
        if (fade == true&&F<0.7f) 
        {
            F += 0.8f * Time.deltaTime;
            Color C = wrningScreen.GetComponent<SpriteRenderer>().color;
            C.a = F;
            wrningScreen.GetComponent<SpriteRenderer>().color = C;
        }
    }
    //mission starters
    public void One()
    {
        if (ObserverScript.Instance.fitSetup[12] == 0 || ObserverScript.Instance.fitSetup[13] == 0)
        {
            fade = true;
            wrningScreen.SetActive(true);
        }
        else
        {
            //set mission to fighter and calculate if mission interrupt should trigger
            ObserverScript.Instance.missionType = 0;
            missionInterruptEvents();
        }
    }
    public void two() 
    {

        if (ObserverScript.Instance.fitSetup[12] == 0 || ObserverScript.Instance.fitSetup[13] == 0)
        {
            fade = true;
            wrningScreen.SetActive(true);
        }
        else
        {
            //set mission to boss and check if mission interupt should trigger
            ObserverScript.Instance.missionType = 1;
            missionInterruptEvents();
        }
    }
    public void three() 
    {

        if (ObserverScript.Instance.fitSetup[12] == 0 || ObserverScript.Instance.fitSetup[13] == 0)
        {
            fade = true;
            wrningScreen.SetActive(true);
        }
        else
        {
            //set mission to static boss and check if mission interupt should trigger
            ObserverScript.Instance.missionType = 2;
            missionInterruptEvents();
        }
    }
}
