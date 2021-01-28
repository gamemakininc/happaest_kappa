using UnityEngine;

public class deathScript : MonoBehaviour
{
    public GameObject endScreen;
    public Animator anim;
    public bool boom=false;


    // Start is called before the first frame update
    void Start()
    {
        //object spawns with deathanimation
        endScreen = GameObject.FindGameObjectWithTag("Finish");
    }
    private void Update()
    {
        //animator toggles variable at end of explosion
        if (boom == true)
        {
            //set fail
            endScreen.GetComponent<esSpawner>().sFail();
            //dissable this script
            GetComponent<deathScript>().enabled = false;
        }
    }
}
