using UnityEngine;

public class continueScript : MonoBehaviour
{
    public int sPlaceholder;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void replacePod() 
    {
        sPlaceholder = ObserverScript.Instance.score/2;
        ObserverScript.Instance.score = sPlaceholder;
        ObserverScript.Instance.deaths = 0;
        FindObjectOfType<sceneManager>().briefing();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
