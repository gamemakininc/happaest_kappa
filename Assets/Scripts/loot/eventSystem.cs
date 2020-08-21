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
                while (swapBool == false)
                {
                    //set rng
                    swapint = Random.Range(0, 7);
                    //unlock something (hopefully)
                    if (swapint == 0)
                    {
                        if (unlocks[1] == false)
                        {
                            //Note 0h 1s 2v appearence of v should be considered a mission NPC
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
                        }
                        else if (unlocks[2] == false)
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
                        }
                        else if (unlocks[3] == false)
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
                        }
                    }
                    else if (swapint == 1)
                    {
                        if (unlocks[4] == false)
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
                        }
                        else if (unlocks[5] == false)
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
                        }
                        else if (unlocks[6] == false)
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
                        }
                    }
                    else if (swapint == 2)
                    {
                        if (unlocks[7] == false)
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
                        }
                        else if (unlocks[8] == false)
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
                        }
                        else if (unlocks[9] == false)
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
                        }
                    }
                    else if (swapint == 3)
                    {
                        if (unlocks[10] == false)
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
                        }
                        else if (unlocks[11] == false)
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
                        }
                        else if (unlocks[12] == false)
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
                        }
                    }
                    else if (swapint == 4)
                    {
                        if (unlocks[13] == false)
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
                        }
                        else if (unlocks[14] == false)
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
                        }
                        else if (unlocks[15] == false)
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
                        }
                    }
                    else if (swapint == 5)
                    {
                        if (unlocks[16] == false)
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
                        }
                        else if (unlocks[17] == false)
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
                        }
                        else if (unlocks[18] == false)
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
                        }
                    }
                    else if (swapint == 6)
                    {
                        if (unlocks[19] == false)
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
                        }
                        else if (unlocks[20] == false)
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
                        }
                        else if (unlocks[21] == false)
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
                        }
                    }
                    else if (swapint == 7)
                    {
                        if (unlocks[22] == false)
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
                        }
                        else if (unlocks[23] == false)
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
                        }
                        else if (unlocks[24] == false)
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
                swapint = Random.Range(0,7);
                //unlock something (hopefully)
                if (swapint == 0) 
                {
                    if (unlocks[1] == false)
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
                    }
                    else if (unlocks[2] == false)
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
                    }
                    else if (unlocks[3] == false)
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
                    }
                }
                else if (swapint == 1) 
                {
                    if (unlocks[4] == false)
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
                    }
                    else if (unlocks[5] == false)
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
                    }
                    else if (unlocks[6] == false)
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
                    }
                }
                else if (swapint == 2)
                {
                    if (unlocks[7] == false)
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
                    }
                    else if (unlocks[8] == false)
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
                    }
                    else if (unlocks[9] == false)
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
                    }
                }
                else if (swapint == 3)
                {
                    if (unlocks[10] == false)
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
                    }
                    else if (unlocks[11] == false)
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
                    }
                    else if (unlocks[12] == false)
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
                    }
                }
                else if (swapint == 4)
                {
                    if (unlocks[13] == false)
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
                    }
                    else if (unlocks[14] == false)
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
                    }
                    else if (unlocks[15] == false)
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
                    }
                }
                else if (swapint == 5)
                {
                    if (unlocks[16] == false)
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
                    }
                    else if (unlocks[17] == false)
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
                    }
                    else if (unlocks[18] == false)
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
                    }
                }
                else if (swapint == 6)
                {
                    if (unlocks[19] == false)
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
                    }
                    else if (unlocks[20] == false)
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
                    }
                    else if (unlocks[21] == false)
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
                    }
                }
                else if (swapint == 7)
                {
                    if (unlocks[22] == false)
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
                    }
                    else if (unlocks[23] == false)
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
                    }
                    else if (unlocks[24] == false)
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
    //unlock secret ships later to be moved to 'questlines' and replaced with missiles(with retuned drop rates)
    {

        eventTriedInterrupt = ObserverScript.Instance.bookmark3;
        eventAllreadyTriggered = ObserverScript.Instance.bookmark0;
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //check for event elegitability
        if (eventTriedInterrupt == true) {/*start mission*/ }
        else if (ObserverScript.Instance.levelsCleared > 15) {/*start mission*/ }
        //reroll check not neccicary because trigger is menu change
        //poll RNG
        else if (swapint <= 20)
        {
            ObserverScript.Instance.bookmark0 = true;
            if (unlocks[25] == false || unlocks[26] == false || unlocks[27] == false)
            {
                if (unlocks[25] == false && ObserverScript.Instance.mProgressMissile < 1)
                {
                    //set observer script var to tell hangar to start missile 1 mission
                    ObserverScript.Instance.esSwap = 1;
                    //set swapint (for debug)
                    swapint = 25;
                }
                else if (unlocks[26] == false && ObserverScript.Instance.mProgressMissile < 4)
                {
                    //set observer script var to tell hangar to start missile 2 mission
                    ObserverScript.Instance.esSwap = 3;
                    //set swapint (for debug)
                    swapint = 26;

                }
                else if (unlocks[27] == false && ObserverScript.Instance.mProgressMissile < 6)
                {
                    //set observer script var to tell hangar to start missile 3 mission
                    ObserverScript.Instance.esSwap = 4;
                    //set swapint (for debug)
                    swapint = 27;

                }
            }
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
                        swapint++;
                    }
                    //increment counter
                    counter++;
                }
                //check avalibility 
                if (swapint > 18)
                {
                    //reset RNG
                    swapint = Random.Range(1, 100);
                    //poll RNG
                    if (swapint <= 20 && ObserverScript.Instance.mProgressShip == 0)
                    {
                        //set observer script var to tell hangar to start ship1 mission
                        ObserverScript.Instance.esSwap = 5;
                        //Note reserve 6,7,8,9 for callbacks from end mission
                    }
                    else if (swapint <= 10 && ObserverScript.Instance.mProgressShip == 6) 
                    {
                        //set observer script var to tell hangar to start ship1 mission
                        ObserverScript.Instance.esSwap = 10;
                        //Note 11,12,13,14,15 are used for mission steps
                    }
                }
                

            }
                if (swapBool == true) { Debug.Log("unlocked" + swapint); }
            
        }
        if (swapBool == false)
        {
            
        }
        if (swapBool != true) 
        {
            sm.gameplay(); 
        }
        eventTriedInterrupt = true;
        ObserverScript.Instance.bookmark3 = true;
    }
    public void hangarEvents()
    {
        if (swapint == 0) { sm.briefing(); Debug.Log("error: no value sent to hangar"); }
        else if (swapint == 1) { cSpeaker.sprite = speakers[2]; msgselect = 0; eventLingth = 6; eventStart(); }
        else if (swapint == 2) { cSpeaker.sprite = speakers[2]; msgselect = 7; eventLingth = 3; eventStart(); }
        else if (swapint == 3) { cSpeaker.sprite = speakers[2]; msgselect = 14; eventLingth = 20; eventStart(); }
        else if (swapint == 4) { cSpeaker.sprite = speakers[2]; msgselect = 21; eventLingth = 27; eventStart(); }
        else if (swapint == 3) { cSpeaker.sprite = speakers[2]; msgselect = 28; eventLingth = 34; eventStart(); }
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
    public void m1unlockfailed() 
    {
        if (msgselect == 7) { }//request
        //if (msgselect == 8) { } responce 1 (should never be true) "yes"
        //if (msgselect == 9) { } responce 2 (should never be true) "no"
        if (msgselect == 10) { }//there was an explosion.(mission progress reset)
    }
    public void missileUnlock2()
    {
        if (msgselect == 11) { }
        //if (msgselect == 12) { }
        //if (msgselect == 13) { }
        //if (msgselect == 14) { }
        if (msgselect == 15) { }
        if (msgselect == 16) { }
        if (msgselect == 17) { }
    }
    public void missileUnlock3()
    {
        if (msgselect == 18) { }
        //if (msgselect == 19) { }
        //if (msgselect == 20) { }
        //if (msgselect == 21) { }
        if (msgselect == 22) { }
        if (msgselect == 23) { }
        if (msgselect == 24) { }
    }
    //--------------end refrence
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
            if (msgselect == 0) { msgselect = 5; StartCoroutine(TypeText()); }
            else if (msgselect==3) { msgselect = 5; StartCoroutine(TypeText()); }
            //missile2
            else if (msgselect == 7) { msgselect = 12; StartCoroutine(TypeText()); }
            else if (msgselect == 11) { msgselect = 12; StartCoroutine(TypeText()); }
            //missile3
            else if (msgselect == 14) { msgselect = 19; StartCoroutine(TypeText()); }
            else if (msgselect == 18) { msgselect = 19; StartCoroutine(TypeText()); }
            //ship1
            else if (msgselect == 21) { msgselect = 26; StartCoroutine(TypeText()); }
            else if (msgselect == 25) { msgselect = 26; StartCoroutine(TypeText()); }
            //ship2
            else if (msgselect == 28) { msgselect = 33; StartCoroutine(TypeText()); }
            else if (msgselect == 34) { msgselect = 33; StartCoroutine(TypeText()); }
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
            else if (msgselect == 3) { msgselect = 6; StartCoroutine(TypeText()); }
            //missile2
            else if (msgselect == 7) { msgselect = 11; StartCoroutine(TypeText()); }
            else if (msgselect == 11) { msgselect = 13; StartCoroutine(TypeText()); }
            //missile3
            else if (msgselect == 14) { msgselect = 18; StartCoroutine(TypeText()); }
            else if (msgselect == 18) { msgselect = 20; StartCoroutine(TypeText()); }
            //ship1
            else if (msgselect == 21) { msgselect = 25; StartCoroutine(TypeText()); }
            else if (msgselect == 25) { msgselect = 27; StartCoroutine(TypeText()); }
            //ship2
            else if (msgselect == 28) { msgselect = 32; StartCoroutine(TypeText()); }
            else if (msgselect == 32) { msgselect = 34; StartCoroutine(TypeText()); }
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
                //check 'fail' states
                if (msgselect == 6 || msgselect == 13 || msgselect == 20)
                {
                    //kick to level
                    sm.gameplay();
                }
                //check 'win' states
                else if (msgselect == 5 || msgselect == 12 || msgselect == 19)
                {
                    //witch one triggered?
                    if (ObserverScript.Instance.esSwap == 1)
                    {
                        //advance story
                        ObserverScript.Instance.mProgressMissile = 1;
                        //go back to mission
                        sm.gameplay();
                    }
                    else if (ObserverScript.Instance.esSwap==2) 
                    {
                        //advance story
                        ObserverScript.Instance.mProgressMissile = 3;
                        //go back to mission
                        sm.gameplay();
                    }
                    else if (ObserverScript.Instance.esSwap == 3)
                    {
                        //advance story
                        ObserverScript.Instance.mProgressMissile = 5;
                        //go back to mission
                        sm.gameplay();
                    }


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
        if (hangar == true)
        {
            btn1Txt.text = ("");
            btn2Txt.text = ("");
        }
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
    private void Update()
    {
        if (slider.transform.position.y>=endPoint.transform.position.y)
        {
            //stop movement
            slider.GetComponent<Rigidbody2D>().velocity = new Vector2(slider.GetComponent<Rigidbody2D>().velocity.x, 0);
        }
    }
    //mission starters
    public void One()
    {
        ObserverScript.Instance.missionType = 0;
        missionInterruptEvents();
    }
    public void two() 
    {
        ObserverScript.Instance.missionType = 1;
        missionInterruptEvents();
    }
    public void three() 
    {
        ObserverScript.Instance.missionType = 2;
        missionInterruptEvents();
    }
}
