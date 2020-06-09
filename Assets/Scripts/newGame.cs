using UnityEngine;
using UnityEngine.UI;

public class newGame : MonoBehaviour
{
    public GameObject startBtn;
    public Toggle[] diffaculty;
    public GameObject nameBox;
    private int counter;

    public void newGameVoid()
    {
        counter = 0;
        while (counter <= 36) 
        {
            ObserverScript.Instance.unlocks[counter] = false;
            counter++;
        }
        ObserverScript.Instance.unlocks[0] = true;
        ObserverScript.Instance.playerName = nameBox.GetComponent<Text>().text;

        if (diffaculty[0].isOn == true)
        {
            counter = 0;
            //loop to collect number of true bool
            while (counter <= 33)
            {
                ObserverScript.Instance.unlocks[counter] = true;
                counter++;
            }
        }
        else if (diffaculty[1].isOn == true)
        {
            ObserverScript.Instance.unlocks[28] = true;
            ObserverScript.Instance.unlocks[29] = true;
            ObserverScript.Instance.unlocks[30] = true;
            ObserverScript.Instance.unlocks[31] = true;
            ObserverScript.Instance.unlocks[32] = true;
            ObserverScript.Instance.unlocks[33] = true;
            ObserverScript.Instance.unlocks[4] = true;
            ObserverScript.Instance.unlocks[1] = true;
        }
        else if (diffaculty[2].isOn == true)
        {

            ObserverScript.Instance.unlocks[28] = true;
            ObserverScript.Instance.unlocks[29] = true;
            ObserverScript.Instance.unlocks[30] = true;
            ObserverScript.Instance.unlocks[31] = true;
        }
        else if (diffaculty[3].isOn == true)
        {

            ObserverScript.Instance.unlocks[28] = true;
            ObserverScript.Instance.unlocks[29] = true;
        }
    }
}
