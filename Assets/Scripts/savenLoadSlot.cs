using UnityEngine;
using UnityEngine.UI;

public class savenLoadSlot : MonoBehaviour
{
    //swap vars
    public int slot;
    private string swapstring;

    public float s1unlocks;
    public int s1Shipselector;
    public int s1clears = 0;
    public string s1name = "Empty";

    public float s2unlocks;
    public int s2Shipselector;
    public int s2clears = 0;
    public string s2name = "Empty";

    public float s3unlocks=1;
    public int s3Shipselector;
    public int s3clears = 0;
    public string s3name = "Empty";
    //load game header locations
    public GameObject namebox;
    public GameObject clearsbox;
    public GameObject spritebox;
    public GameObject unlocksbox;
    public Sprite[] ships;
    public void loadPlaceMats()
    {

        if (slot == 0)
        {
            //populate s1 variables
            s1Shipselector = ObserverScript.Instance.s1Shipselector;
            s1name = ObserverScript.Instance.s1name;
            s1clears = ObserverScript.Instance.s1clears;
            s1unlocks = ObserverScript.Instance.s1unlocks;

            //populate save1box
            namebox.GetComponent<Text>().text = s1name;
            clearsbox.GetComponent<Text>().text = s1clears + "";
            spritebox.GetComponent<SpriteRenderer>().sprite = ships[s1Shipselector];
            float a = s1unlocks / 37;
            s1unlocks = a * 100;
            s1unlocks=Mathf.RoundToInt(s1unlocks);
            unlocksbox.GetComponent<Text>().text = s1unlocks + "%";
        }
        else if (slot == 1)
        {
            //populate s2 variables
            s2Shipselector = ObserverScript.Instance.s2Shipselector;
            s2name = ObserverScript.Instance.s2name;
            s2clears = ObserverScript.Instance.s2clears;
            s2unlocks = ObserverScript.Instance.s2unlocks;

            //populate save2box
            namebox.GetComponent<Text>().text = s2name;
            clearsbox.GetComponent<Text>().text = s2clears + "";
            spritebox.GetComponent<SpriteRenderer>().sprite = ships[s2Shipselector];
            float a = s2unlocks / 37;
            s2unlocks = a * 100;
            s2unlocks=Mathf.RoundToInt(s2unlocks);
            unlocksbox.GetComponent<Text>().text = s2unlocks + "%";
        }
        else if (slot == 2)
        {
            //populate s3 variables
            s3Shipselector = ObserverScript.Instance.s3Shipselector;
            s3name = ObserverScript.Instance.s3name;
            s3clears = ObserverScript.Instance.s3clears;
            s3unlocks = ObserverScript.Instance.s3unlocks;

            //populate save3box
            namebox.GetComponent<Text>().text = s3name;
            clearsbox.GetComponent<Text>().text = s3clears + "";
            spritebox.GetComponent<SpriteRenderer>().sprite = ships[s3Shipselector];
            float a = s3unlocks / 37;
            s3unlocks = a * 100;
            s3unlocks = Mathf.RoundToInt(s3unlocks);
            unlocksbox.GetComponent<Text>().text = s3unlocks + "%";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        loadPlaceMats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
