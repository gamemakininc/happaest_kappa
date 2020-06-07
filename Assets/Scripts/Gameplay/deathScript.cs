using UnityEngine;

public class deathScript : MonoBehaviour
{
    public GameObject sceneManedgerCan;
    public bool end;
    public int ship;
    public bool[] unlocks;

    // Start is called before the first frame update
    void Start()
    {
        sceneManedgerCan = GameObject.FindWithTag("MainCamera");
        unlocks = ObserverScript.Instance.unlocks;
    }
    public void death()
    {
        //lock current ship
        if (ship == 0) { ObserverScript.Instance.unlocks[28]= false; }
        else if (ship == 1) { ObserverScript.Instance.unlocks[29] = false; }
        else if (ship == 2) { ObserverScript.Instance.unlocks[30] = false; }
        else if (ship == 3) { ObserverScript.Instance.unlocks[31] = false; }
        else if (ship == 4) { ObserverScript.Instance.unlocks[32] = false; }
        else if (ship == 5) { ObserverScript.Instance.unlocks[33] = false; }
        else if (ship == 6) { ObserverScript.Instance.unlocks[34] = false; }
        else if (ship == 7) { ObserverScript.Instance.unlocks[35] = false; }
        //update local array
        unlocks = ObserverScript.Instance.unlocks;
        //really long statement to check if it was last ship
        if (unlocks[28] == false && unlocks[29] == false && unlocks[30] == false && unlocks[31] == false && unlocks[32] == false && unlocks[33] == false && unlocks[34] == false && unlocks[35] == false)
        {//game over
            sceneManedgerCan.GetComponent<sceneManager>().mainMenu();
        }
        else { sceneManedgerCan.GetComponent<sceneManager>().testMenu(); }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
