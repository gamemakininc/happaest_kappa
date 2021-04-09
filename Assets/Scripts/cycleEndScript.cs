using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class cycleEndScript : MonoBehaviour
{
    public Text[] UItext;
    public Button[] buttons;
    public int score;
    public int deaths;
    public float drainIntervol;
    bool drain;
    bool swapBool;
    int podCost;
    int ships;
    int moduals;
    private void Update()
    {
        UItext[0].text = (ObserverScript.Instance.cycles + " cycles");
        UItext[1].text = (moduals + " moduals and "+ships+" ships");
        UItext[2].text = (score + " Credits");
        UItext[3].text = ("lost "+ deaths +" ships");
    }
    private void Start()
    {
        //coppy variables from observer script
        score = ObserverScript.Instance.score;
        deaths = ObserverScript.Instance.deaths;
        //set pod cost
        podCost = score / Random.Range(2,6) ;
        //check modual unlocks
        if (ObserverScript.Instance.unlocks[1] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[2] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[3] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[4] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[5] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[6] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[7] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[8] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[9] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[10] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[11] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[12] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[13] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[14] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[15] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[16] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[17] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[18] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[19] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[20] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[21] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[22] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[23] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[24] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[25] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[26] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[27] == true) { moduals++; }
        //check ship unlocks
        if (ObserverScript.Instance.unlocks[28] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[29] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[30] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[31] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[32] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[33] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[34] == true) { moduals++; }
        if (ObserverScript.Instance.unlocks[35] == true) { moduals++; }
        //set drain intervol
        drainIntervol = 0.1f;
        //set UI textboxes
        if (ships < 6 || moduals < 24)
        {
            string message=":";
            string shipsL = ("there are more ships to collect");
            string modualsL = ("there are more modules to unlock.");
            if (ships < 6) 
            {
                message = (shipsL+".");
            }
            else if (moduals < 24)
            {
                message = (modualsL);
            }
            if (ships < 6 && moduals < 24) 
            {
                message = (shipsL + " and " + modualsL);
            }
            UItext[5].text = (message);
        }

        if (score < 3000)
        {
            UItext[4].text = ("take a few years off.");
        }
        else if (score > 3000 && score < 15000)
        {
            UItext[4].text = ("retire.");
        }
        else if (score > 15000 && score < 20000) 
        {
            UItext[4].text = ("buy a corvette.");
        }
        else if (score > 20000 && score < 50000)
        {
            UItext[4].text = ("buy your own cruiser.");
        }
        else if (score > 50000 && score < 100000)
        {
            UItext[4].text = ("buy a small carrier.");
        }
        else if (score > 100000)
        {
            UItext[4].text = ("buy and crew a nedium carrier.");
        }
    }
    public void endGame()
    {
        swapBool = false;
        drainScore();
    }
    public void resume()
    {
        FindObjectOfType<sceneManager>().briefing();
        ObserverScript.Instance.cycles++;
    }
    public void resumeNReset()
    {
        
        swapBool = true;
        drain = true;
        drainScore();

    }
    IEnumerator drainScore()
    {
        
        
        while (drain==true)
        {
            if (swapBool==true) 
            {
                if (score > podCost)
                {
                    score -= 122;
                }
                else if (score <= podCost)
                {
                    ObserverScript.Instance.deaths = 0;
                    score = podCost;
                    drain = false;
                    ObserverScript.Instance.score = score;
                }
            }
            else if (swapBool==false) 
            {
                //drain moduals
                if (moduals > 0)
                {
                    moduals--;
                    score += 150;
                }
                //than ships
                else if (ships > 0)
                {
                    ships--;
                    score += 2065;
                }
                //end loop
                else 
                {
                    ObserverScript.Instance.hardReset();

                    drain = false;
                    break;
                }
            }
            
            
            yield return 0;
            yield return new WaitForSeconds(drainIntervol);
            //if done
            if (drain == false)
            {
                //wait
                yield return new WaitForSeconds(5);
                //change scene
                if (swapBool == true)
                { 
                    FindObjectOfType<sceneManager>().briefing();
                    ObserverScript.Instance.cycles++;
                }
                else if (swapBool == false) 
                { 
                    FindObjectOfType<sceneManager>().mainMenu(); 
                }
            }
        }
        //tell button loop is over
        drain = false;
    }
}
