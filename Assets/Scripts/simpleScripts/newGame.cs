using UnityEngine;
using UnityEngine.UI;

public class newGame : MonoBehaviour
{
    public GameObject startBtn;
    public Toggle[] diffaculty;
    public GameObject nameBox;
    private int counter;
    sceneManager sceneManager;

    private void Start()
    {
        sceneManager = FindObjectOfType<sceneManager>();
    }
    public void newGameVoid()
    {
        counter = 0;
        //clear all unlocks
        while (counter <= 36) 
        {
            ObserverScript.Instance.unlocks[counter] = false;
            counter++;
        }
        //unlock0 should allways be unlocked
        ObserverScript.Instance.unlocks[0] = true;
        //get player name
        ObserverScript.Instance.playerName = nameBox.GetComponent<Text>().text;

        //if easiest selected
        if (diffaculty[0].isOn == true)
        {
            //set difficulty tracker to lowest position
            ObserverScript.Instance.diff = 0;
            //reset counter
            counter = 0;
            //loop to unlock all the things
            while (counter <= 33)
            {
                ObserverScript.Instance.unlocks[counter] = true;
                counter++;
            }
            ObserverScript.Instance.shipswap = 5;
        }
        else if (diffaculty[1].isOn == true)
        {
            //set difficulty tracker
            ObserverScript.Instance.diff = 1;
            //unlock easy specific items
            ObserverScript.Instance.unlocks[28] = true;
            ObserverScript.Instance.unlocks[29] = true;
            ObserverScript.Instance.unlocks[30] = true;
            ObserverScript.Instance.unlocks[31] = true;
            ObserverScript.Instance.unlocks[32] = true;
            ObserverScript.Instance.unlocks[33] = true;
            ObserverScript.Instance.unlocks[4] = true;
            ObserverScript.Instance.unlocks[1] = true;
            ObserverScript.Instance.shipswap = 5;
        }
        else if (diffaculty[2].isOn == true)
        {
            //set difficulty tracker
            ObserverScript.Instance.diff = 2;
            //unlock medium specific items
            ObserverScript.Instance.unlocks[28] = true;
            ObserverScript.Instance.unlocks[29] = true;
            ObserverScript.Instance.unlocks[30] = true;
            ObserverScript.Instance.unlocks[31] = true;
            ObserverScript.Instance.shipswap = Random.Range(5,10);
        }
        else if (diffaculty[3].isOn == true)
        {
            //set difficulty tracker to highest position
            ObserverScript.Instance.diff = 3;
            //unlock hard specific items
            ObserverScript.Instance.unlocks[28] = true;
            ObserverScript.Instance.unlocks[29] = true;
            ObserverScript.Instance.shipswap = 20;
        }
        sceneManager.briefing();
    }
}
