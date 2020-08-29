﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class endScreenScript : MonoBehaviour
{
    int scoreholder;
    sceneManager sm;
    public GameObject[] igUi;
    public GameObject skipBtn;
    bool drain;
    int swapint1;
    public GameObject[] scoreBoxes;
    public float drainIntervol;
    public GameObject winBtn;
    public GameObject failBtn;
    public bool win;
    private bool lockedState;
    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<sceneManager>();
        int I = 0;
        lockedState = win;
        if (lockedState == true)
        {
            winBtn.SetActive(true);
            failBtn.SetActive(false);
        }
        else
        {
            failBtn.SetActive(true);
            winBtn.SetActive(false);
        }
        StartCoroutine(drainScore());
        while (I > igUi.Length ) { igUi[I].SetActive(false); I++; }

    }
    IEnumerator drainScore()
    {
        scoreholder = ObserverScript.Instance.levelScore;
        drain = true;
        //l00p to drain lvl score into total score
        while (ObserverScript.Instance.levelScore>0)
        {

            //if skip hit end early.
            if (drain == false)
            { break; }
            if (ObserverScript.Instance.levelScore >= 32)
            {
                ObserverScript.Instance.levelScore -= 32;
                if (lockedState == true)
                {
                    ObserverScript.Instance.score += 32;
                }
            }
            else if (ObserverScript.Instance.levelScore < 26) 
            {
                swapint1 = ObserverScript.Instance.levelScore;
                ObserverScript.Instance.levelScore=0;
                if (lockedState == true)
                {
                    ObserverScript.Instance.score += swapint1;
                }
            }
            yield return 0;
            yield return new WaitForSeconds(drainIntervol);
        }
        //tell button loop is over
        drain = false;
        skipBtn.SetActive(false);
    }
    public void skipAnim() 
    {//activated by a button
        drain = false;
        skipBtn.SetActive(false);
        swapint1 = ObserverScript.Instance.levelScore;
        ObserverScript.Instance.levelScore = 0;
        ObserverScript.Instance.score += swapint1;
    }
    // Update is called once per frame
    void Update()
    {
        scoreBoxes[0].GetComponent<Text>().text = ("Level Score: "+ ObserverScript.Instance.levelScore);
        scoreBoxes[1].GetComponent<Text>().text = ("Total Score: " + ObserverScript.Instance.score);
    }
    public void winState() 
    {

        //count level cleared
        ObserverScript.Instance.levelsCleared++;
        //reset bookmarks
        ObserverScript.Instance.bookmark0 = false;
        ObserverScript.Instance.bookmark1 = false;
        ObserverScript.Instance.bookmark2 = false;
        ObserverScript.Instance.bookmark3 = false;
        //misson progress check
        if (ObserverScript.Instance.mProgressMissile == 1) 
        {
            int i = Random.Range(1, 100);
            if (i < 30)
            {
                ObserverScript.Instance.unlocks[25] = true;
            }
            else if (i >= 30) 
            {
                ObserverScript.Instance.esSwap = 2;
                sm.hangar();
            }
        }//misson progress check (M1)
        if (ObserverScript.Instance.mProgressMissile == 3) 
        {
            ObserverScript.Instance.unlocks[26] = true;
        }//misson progress check (M2)
        if (ObserverScript.Instance.mProgressMissile == 5)
        {
            ObserverScript.Instance.unlocks[27] = true;
        }//misson progress check (M3)

        if (ObserverScript.Instance.mProgressShip==1&& ObserverScript.Instance.missionType==1) { ObserverScript.Instance.mProgressShip++; }
        if (ObserverScript.Instance.mProgressShip == 3&&scoreholder>1000+ ObserverScript.Instance.levelsCleared*2.5f) 
        {
            ObserverScript.Instance.mProgressShip++;
            ObserverScript.Instance.unlocks[34] = true;
        }//incroment ship mission and unlock first hidden ship

        if (ObserverScript.Instance.mProgressShip == 5&& ObserverScript.Instance.missionType == 1) { ObserverScript.Instance.mProgressShip++; }
        if (ObserverScript.Instance.mProgressShip == 7 && scoreholder > 5000 + ObserverScript.Instance.levelsCleared * 4) { ObserverScript.Instance.mProgressShip++; }
        if (ObserverScript.Instance.mProgressShip == 9 && ObserverScript.Instance.missionType == 2) { ObserverScript.Instance.mProgressShip++; }
        if (ObserverScript.Instance.mProgressShip == 11 && scoreholder > 7000 && ObserverScript.Instance.missionType == 0) 
        {
            ObserverScript.Instance.unlocks[35] = true;
            ObserverScript.Instance.mProgressShip++;
        }//incroment ship mission and unlock second hidden ship
         //change scene
        sm.briefing();
    }
    public void failState() 
    {
        //reset bookmarks
        ObserverScript.Instance.bookmark0 = false;
        ObserverScript.Instance.bookmark1 = false;
        ObserverScript.Instance.bookmark2 = false;
        ObserverScript.Instance.bookmark3 = false;
        //misson progress check
        if (ObserverScript.Instance.mProgressMissile == 1)
        {
            //other missions will not have a fail state check
            int i = Random.Range(1, 100);
            if (i > 30)
            {
                ObserverScript.Instance.unlocks[25] = true;
            }
            else if (i <= 30)
            {
                ObserverScript.Instance.esSwap = 2;
                sm.hangar();
            }
        }
        //change scene
        sm.briefing();
    }
}
