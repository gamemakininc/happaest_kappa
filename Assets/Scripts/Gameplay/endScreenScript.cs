﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class endScreenScript : MonoBehaviour
{
    int scoreholder;
    sceneManager sm;
    //i dont know what igUi is for
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
        
        //wut is this for?
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
            if (ObserverScript.Instance.levelScore >= 55)
            {
                ObserverScript.Instance.levelScore -= 55;
                if (lockedState == true)
                {
                    ObserverScript.Instance.score += 55;
                }
            }
            else if (ObserverScript.Instance.levelScore < 55) 
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
                //success unlock missile
                ObserverScript.Instance.unlocks[25] = true;
                //incromint mission progress tracker
                ObserverScript.Instance.mProgressMissile=3;
            }
            else if (i >= 30) 
            {
                //set eswap to 'm1 failed
                ObserverScript.Instance.esSwap = 2;
                //incromint mission progress tracker
                ObserverScript.Instance.mProgressMissile = 2;
                //start event
                sm.hangar();
            }
        }//misson progress check (M1)
        if (ObserverScript.Instance.mProgressMissile == 3) 
        {
            ObserverScript.Instance.unlocks[26] = true;
            //incromint mission progress tracker
            ObserverScript.Instance.mProgressMissile++;
        }//misson progress check (M2)
        if (ObserverScript.Instance.mProgressMissile == 5)
        {
            ObserverScript.Instance.unlocks[27] = true;
            //incromint mission progress tracker
            ObserverScript.Instance.mProgressMissile++;
        }//misson progress check (M3)

        if (ObserverScript.Instance.mProgressShip==1&& ObserverScript.Instance.missionType==1) { ObserverScript.Instance.mProgressShip++; }
        if (ObserverScript.Instance.mProgressShip == 3&&scoreholder>1000) 
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
        
        //lock active ship
        switch (ObserverScript.Instance.fitSetup[13])
        {
            //what ship
            case 1:
                {
                    //lock ship
                    ObserverScript.Instance.unlocks[28] = false;
                    //end switch
                    break;
                }
            case 2:
                {
                    //lock ship
                    ObserverScript.Instance.unlocks[29] = false;
                    break;
                }
            case 3:
                {
                    //lock ship
                    ObserverScript.Instance.unlocks[30] = false;
                    break;
                }
            case 4:
                {
                    //lock ship
                    ObserverScript.Instance.unlocks[31] = false;
                    break;
                }
            case 5:
                {
                    //lock ship
                    ObserverScript.Instance.unlocks[32] = false;
                    break;
                }
            case 6:
                {
                    //lock ship
                    ObserverScript.Instance.unlocks[33] = false;
                    break;
                }
            case 7:
                {
                    //lock ship
                    ObserverScript.Instance.unlocks[34] = false;
                    break;
                }
            case 8:
                {
                    //lock ship
                    ObserverScript.Instance.unlocks[35] = false;
                    break;
                }
        }


        //reset fitting
        ObserverScript.Instance.clearFitting();
        int _deaths = ObserverScript.Instance.deaths;
        int i;
        switch (_deaths) 
        {
            case 0:
                //do nothing
                break;

            case 1:
                i = Random.Range(0,100);
                if (i < 5) 
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 2:
                i = Random.Range(0, 100);
                if (i < 15)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 3:
                i = Random.Range(0, 100);
                if (i < 25)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 4:
                i = Random.Range(0, 100);
                if (i < 35)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 5:
                i = Random.Range(0, 100);
                if (i < 55)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 6:
                i = Random.Range(0, 100);
                if (i < 65)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 7:
                i = Random.Range(0, 100);
                if (i < 75)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 8:
                i = Random.Range(0, 100);
                if (i < 85)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 9:
                i = Random.Range(0, 100);
                if (i < 95)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            case 10:
                i = Random.Range(0, 100);
                if (i < 100)
                {
                    ObserverScript.Instance.poped = true;
                    sm.gameOver();
                }
                break;
            default:
                ObserverScript.Instance.poped = true;
                sm.gameOver();
                break;
        }
        

        //really long statement to check if it was last ship
        if 
            (ObserverScript.Instance.unlocks[28] == false && ObserverScript.Instance.unlocks[29] == false && ObserverScript.Instance.unlocks[30] == false && ObserverScript.Instance.unlocks[31] == false && ObserverScript.Instance.unlocks[32] == false && ObserverScript.Instance.unlocks[33] == false && ObserverScript.Instance.unlocks[34] == false && ObserverScript.Instance.unlocks[35] == false)
        {//game over
            sm.gameOver();
        }
        if (ObserverScript.Instance.mProgressMissile == 1)
        {
            //other missions will not have a fail state check
            i = Random.Range(1, 100);
            if (i < 30)
            {
                //success unlock missile
                ObserverScript.Instance.unlocks[25] = true;
                //incromint mission progress tracker
                ObserverScript.Instance.mProgressMissile = 3;
            }
            else if (i >= 30)
            {
                //set eswap to 'm1 failed
                ObserverScript.Instance.esSwap = 2;
                //incromint mission progress tracker
                ObserverScript.Instance.mProgressMissile = 2;
                //start event
                sm.hangar();
            }
        }
        //if you didnt game over by this point return to briefing room
        sm.briefing();
    }
}
