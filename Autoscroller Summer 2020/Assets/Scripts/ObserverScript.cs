using UnityEngine;
using UnityEngine.UI;

public class ObserverScript : MonoBehaviour
{
    public static ObserverScript Instance { get; private set; }
    //player output from fitting system
    public int pBulletSelector;
    public float pSpeed;
    public float pHealth;
    public int[] fitSetup;
    public float pShield;
    public float pSRegen;
    public float pRepair;
    public int mslBonus;
    //save for player payload slot0-1
    public int pP0;
    public int pP1;
    //misc savegame variables
    public bool[] unlocks;
    public int levelsCleared;
    public string playerName;
    //swap vars
    private string swapstring;
    public int s1Shipselector;
    public int s1clears=0;
    public string s1name="Empty";
    public int s2Shipselector;
    public int s2clears=0;
    public string s2name="Empty";
    public int s3Shipselector;
    public int s3clears=0;
    public string s3name="Empty";
    //load game header locations
    public GameObject s1namebox;
    public GameObject s1clearsbox;
    public GameObject s1spritebox;
    public GameObject s2namebox;
    public GameObject s2clearsbox;
    public GameObject s2spritebox;
    public GameObject s3namebox;
    public GameObject s3clearsbox;
    public GameObject s3spritebox;
    public Sprite[] ships;
    private void Awake()
    {//
        if (Instance == null)
        {//
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    public void loadPlaceMats()
    {
        //populate save1box
        s1namebox.GetComponent<Text>().text = s1name;
        swapstring = s1clears+"";
        s1clearsbox.GetComponent<Text>().text = swapstring;
        s1spritebox.GetComponent<SpriteRenderer>().sprite = ships[s1Shipselector];

        //populate save2box
        s2namebox.GetComponent<Text>().text = s2name;
        swapstring = s2clears + "";
        s2clearsbox.GetComponent<Text>().text = swapstring;
        s2spritebox.GetComponent<SpriteRenderer>().sprite = ships[s2Shipselector];

        //populate save3mox
        s3namebox.GetComponent<Text>().text = s3name;
        swapstring = s3clears + "";
        s3clearsbox.GetComponent<Text>().text = swapstring;
        s3spritebox.GetComponent<SpriteRenderer>().sprite = ships[s3Shipselector];

    }
    private void Start()
    {


    }


}
