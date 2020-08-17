using UnityEngine;
using UnityEngine.UI;
public class levelUIscript : MonoBehaviour
{
    public int score;
    public GameObject scoreTxt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score = ObserverScript.Instance.levelScore;
        scoreTxt.GetComponent<Text>().text = "score: " + score;
    }
}