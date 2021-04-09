using UnityEngine;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour
{
    public bool poped;
    public Text[] UiText;
    public GameObject stars;
    // Start is called before the first frame update
    void Start()
    {
        poped = ObserverScript.Instance.poped;
        if (poped == true)
        {
            UiText[0].text = "your pod floats quietly in space as it has every other time as you wait for pickup. several minutes pass before your missile lock warnings go off, moments later the thin walls protecting you from the vacuum of space vanish in an instant.";
            UiText[1].text = "but on the plus side you earned " + ObserverScript.Instance.score + "Credits.";
            stars.SetActive(true);
            ObserverScript.Instance.hardReset();
        }
        else 
        {
            UiText[0].text = "with no more ships at your disposal you can take on small jobs around the ship but mostly just kill time until the Cerberus next docks.";
            UiText[1].text = "but on the plus side you earned " + ObserverScript.Instance.score + "Credits.";
            stars.SetActive(false);
            ObserverScript.Instance.hardReset();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
