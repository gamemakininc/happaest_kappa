using UnityEngine;
using UnityEngine.UI;
public class levelUIscript : MonoBehaviour
{
    public int score;
    public Text bombText;
    public Text scoreTxt;
    public PlayerScript ps;
    string bombType;
    string stateText;
    bool defence;

    // Start is called before the first frame update
    void Start()
    {
        defence = ObserverScript.Instance.defenceMission;
        //check mission type
        if (defence == true)
        {
            bombType = ("fire support: ");
        }
        else
        {
            bombType = ("bomb status: ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = ObserverScript.Instance.levelScore;
        scoreTxt.GetComponent<Text>().text = "score: " + score;
        //mission type
        if (defence == true)
        {
            //get readystate
            if (ps.bombReady == true)
            {
                stateText = ("ready");
            }
            else
            {
                stateText = ("reloading");
            }
        }
        else
        {
            //get readystate
            if (ps.bombReady == true)
            {
                stateText = ("ready");
            }
            else
            {
                stateText = ("depleted");
            }
        }
        //print bomb status if updated
        if (bombText.text != (bombType + stateText))
        {
            bombText.text = (bombType + stateText);
        }

    }
}