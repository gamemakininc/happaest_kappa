using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class endScreenScript : MonoBehaviour
{
    sceneManager sm;
    public GameObject[] igUi;
    public GameObject skipBtn;
    public bool drain;
    public int swapint1;
    public GameObject[] scoreBoxes;
    public float drainIntervol;
    public GameObject winBtn;
    public GameObject failBtn;
    bool win;
    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<sceneManager>();
        int I = 0;
        if (win == true)
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
                if (win == true)
                {
                    ObserverScript.Instance.score += 32;
                }
            }
            else if (ObserverScript.Instance.levelScore < 26) 
            {
                swapint1 = ObserverScript.Instance.levelScore;
                ObserverScript.Instance.levelScore=0;
                if (win == true)
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
        //change scene
        sm.briefing();
    }
}
