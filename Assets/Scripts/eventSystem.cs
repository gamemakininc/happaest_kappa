using UnityEngine;

public class eventSystem : MonoBehaviour
{
    public bool eventAllreadyTriggered=false;
    public bool eventTriedhangar=false;
    public bool eventTriedBriefing=false;
    public bool[] unlocks;
    private int swapint;
    public void hangarLoadEvents()
        //aircraft unlocks than mods
    {
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //check if event elegitability
        if (eventAllreadyTriggered == true) {/*do nothing*/ }
        else if (eventTriedhangar == true) {/*do nothing*/ }
        //poll RNG
        else if (swapint <= 15) { }
        eventTriedhangar = true;

    }
    public void briefingLoadEvents()
        //mod unlocks
    {
        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //check if event elegitability
        if (eventAllreadyTriggered == true) {/*do nothing*/ }
        else if (eventTriedhangar == true) {/*do nothing*/ }
        //poll RNG
        else if (swapint <= 15) { }
    }
    public void missionInterruptEvents()
    //unlock secret ships
    {

        swapint = Random.Range(1, 100);
        unlocks = ObserverScript.Instance.unlocks;
        //check if event elegitability
        if (eventAllreadyTriggered == true) {/*do nothing*/}
        else if (ObserverScript.Instance.levelsCleared <= 50) {/*do nothing*/}
        //second check not neccicary because trigger is menu change
        //poll RNG
        else if (swapint <= 5) { }
    }
}
