using UnityEngine;
using UnityEngine.UI;

public class eventSystem : MonoBehaviour
{
    public GameObject mstartbtn;
    public bool eventAllreadyTriggered=false;
    public bool eventTriedhangar=false;
    public bool eventTriedBriefing=false;
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
        eventTriedhangar = ObserverScript.Instance.bookmark1;
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //reset swapbool
        swapBool = false;
        //check for event elegitability
        if (eventAllreadyTriggered == true) {/*do nothing*/ }
        else if (eventTriedhangar == true) {/*do nothing*/ }
        else if (ObserverScript.Instance.levelsCleared <= 0) {/*do nothing*/}
        //poll RNG
        else if (swapint <= 60)
        {

            ObserverScript.Instance.bookmark0 = true;
            counter = 0;
            //should skip loop if all ships unlocked
            if (unlocks[28] == true && unlocks[29] == true && unlocks[30] == true && unlocks[31] == true) { swapBool = true; }
            //loop till something unlocks?    
            while (swapBool == false)
            {
                //set rng
                swapint = Random.Range(1, 4);
                //unlock something (hopefully)
                if (unlocks[28] == false && swapint == 1) { swapBool = true; ObserverScript.Instance.unlocks[28] = true; }
                if (unlocks[29] == false && swapint == 2) { swapBool = true; ObserverScript.Instance.unlocks[29] = true; }
                if (unlocks[30] == false && swapint == 3) { swapBool = true; ObserverScript.Instance.unlocks[30] = true; }
                if (unlocks[31] == false && swapint == 4) { swapBool = true; ObserverScript.Instance.unlocks[31] = true; }
                counter++;

                //escape clause incase number dosent come up in reasonable time.
                if (counter >= 20) {  Debug.Log("attempted to unlock and failed"); break; }
                if (swapBool == true) { Debug.Log("unlocked" + swapint); }
            }
            //check if all ships unlocked
            if (unlocks[28] == true && unlocks[29] == true && unlocks[30] == true && unlocks[31] == true) 
            {
                counter = 0;
                swapBool = false;

                //loop till something unlocks?   
                while (swapBool == false)
                {
                    //set rng
                    swapint = Random.Range(1, 6);
                    //unlock something (hopefully)
                    if (unlocks[1] == false && swapint == 1) { swapBool = true; ObserverScript.Instance.unlocks[1] = true; }
                    if (unlocks[2] == false && swapint == 2) { swapBool = true; ObserverScript.Instance.unlocks[2] = true; }
                    if (unlocks[3] == false && swapint == 3) { swapBool = true; ObserverScript.Instance.unlocks[3] = true; }
                    if (unlocks[4] == false && swapint == 4) { swapBool = true; ObserverScript.Instance.unlocks[4] = true; }
                    if (unlocks[5] == false && swapint == 5) { swapBool = true; ObserverScript.Instance.unlocks[5] = true; }
                    if (unlocks[6] == false && swapint == 6) { swapBool = true; ObserverScript.Instance.unlocks[6] = true; }
                    counter++;
                    //escape clause incase number dosent come up in reasonable time.
                    if (counter >= 20) { Debug.Log("attempted to unlock and failed"); break; }
                    if (swapBool == true) { Debug.Log("unlocked" + swapint); }
                }
            }
        }

        //dissable ability to retrigger
        eventTriedhangar = true;
        //update bookmark (reset on mission completion or fail do not reset on mission start)
        ObserverScript.Instance.bookmark1= eventTriedhangar;
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
                swapint = Random.Range(1, 18);
                //unlock something (hopefully)
                if (unlocks[7] == false && swapint == 1) { swapBool = true; ObserverScript.Instance.unlocks[7] = true; }
                if (unlocks[8] == false && swapint == 2) { swapBool = true; ObserverScript.Instance.unlocks[8] = true; }
                if (unlocks[9] == false && swapint == 3) { swapBool = true; ObserverScript.Instance.unlocks[9] = true; }
                if (unlocks[10] == false && swapint == 4) { swapBool = true; ObserverScript.Instance.unlocks[10] = true; }
                if (unlocks[11] == false && swapint == 5) { swapBool = true; ObserverScript.Instance.unlocks[11] = true; }
                if (unlocks[12] == false && swapint == 6) { swapBool = true; ObserverScript.Instance.unlocks[12] = true; }
                if (unlocks[13] == false && swapint == 7) { swapBool = true; ObserverScript.Instance.unlocks[13] = true; }
                if (unlocks[14] == false && swapint == 8) { swapBool = true; ObserverScript.Instance.unlocks[14] = true; }
                if (unlocks[15] == false && swapint == 9) { swapBool = true; ObserverScript.Instance.unlocks[15] = true; }
                if (unlocks[16] == false && swapint == 10) { swapBool = true; ObserverScript.Instance.unlocks[16] = true; }
                if (unlocks[17] == false && swapint == 11) { swapBool = true; ObserverScript.Instance.unlocks[17] = true; }
                if (unlocks[18] == false && swapint == 12) { swapBool = true; ObserverScript.Instance.unlocks[18] = true; }
                if (unlocks[19] == false && swapint == 13) { swapBool = true; ObserverScript.Instance.unlocks[19] = true; }
                if (unlocks[20] == false && swapint == 14) { swapBool = true; ObserverScript.Instance.unlocks[20] = true; }
                if (unlocks[21] == false && swapint == 15) { swapBool = true; ObserverScript.Instance.unlocks[21] = true; }
                if (unlocks[22] == false && swapint == 16) { swapBool = true; ObserverScript.Instance.unlocks[29] = true; }
                if (unlocks[23] == false && swapint == 17) { swapBool = true; ObserverScript.Instance.unlocks[22] = true; }
                if (unlocks[24] == false && swapint == 18) { swapBool = true; ObserverScript.Instance.unlocks[24] = true; }
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
    }
    public void missionInterruptEvents()
    //unlock secret ships later to be moved to 'questlines' and replaced with missiles(with retuned drop rates)
    {
        eventAllreadyTriggered = ObserverScript.Instance.bookmark0;
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //check for event elegitability
        if (eventAllreadyTriggered == true) {/*do nothing*/}
        else if (ObserverScript.Instance.levelsCleared <= 50) {/*do nothing*/}
        //reroll check not neccicary because trigger is menu change
        //poll RNG
        else if (swapint <= 20)
        { // i would like to make this one launch its own scene later
            mstartbtn.GetComponent<Button>().interactable=false;
            ObserverScript.Instance.bookmark0 = true;
            counter = 0;
            while (swapBool == false)
            {

                //set rng
                swapint = Random.Range(1, 3);
                //unlock something (hopefully)
                if (unlocks[32] == false && swapint == 1) { swapBool = true; ObserverScript.Instance.unlocks[7] = true; }
                if (unlocks[33] == false && swapint == 2) { swapBool = true; ObserverScript.Instance.unlocks[8] = true; }
                if (unlocks[33] == true && unlocks[32] == true)
                {
                if (unlocks[34] == false&& swapint==1 || swapint==3) { swapBool = true; ObserverScript.Instance.unlocks[9] = true; }
                }
                counter++;
                //escape clause incase number dosent come up in reasonable time.
                if (counter >= 20) { Debug.Log("attempted to unlock and failed"); break; }
                if (swapBool == true) { Debug.Log("unlocked" + swapint); }
            }
            mstartbtn.GetComponent<Button>().interactable = true;
        }
        //no reset measure needed as trigger is mission start btn
    }
    private void Start()
    {
        if (briefing == true) { briefingLoadEvents(); }
        else if (fitting == true) { fittingLoadEvents(); }
    }
}
