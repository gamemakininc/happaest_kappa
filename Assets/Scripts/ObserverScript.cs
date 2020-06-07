using UnityEngine;

public class ObserverScript : MonoBehaviour
{
    public static ObserverScript Instance { get; private set; }
    //unlocks 
    /*
      should corrispond to 'item designator'
      zero should allways be true!
      0          default unlocks(slot clears t1 ships)
      1-3,7-9    shields
      4-6,10-12  health
      13-18      speed mods
      19-24      misc mods
      25-27      missiles
      28-35      ships (last two should have spechal unlock conditions)
      36         guns (should be last unlock)
    */
    public bool[] unlocks;
    //player output from fitting system
    public float efireRate;
    public float fireRate;
    public int pBulletSelector;
    public float pSpeed;
    public float pHealth;
    public float pShield;
    public float pSRegen;
    public float pRepair;
    public int mslBonus;
    //0-4 high slots, 5-9 low slots, 10-11 payload, 12 gun , 13 ship
    //value of 0 for empty slot
    public int[] fitSetup;

    //save for player payload slot0-1
    public int pP0;
    public int pP1;
    //misc savegame variables
    public int levelsCleared;
    public string playerName;
    //swap vars
    public bool bookmark0;
    public bool bookmark1;
    public bool bookmark2;


    //save preview variables slot1
    public int s1Shipselector;
    public int s1clears=0;
    public string s1name="Empty";
    public float s1unlocks=0.1f;
    //save preview variables slot2
    public int s2Shipselector;
    public int s2clears=0;
    public string s2name="Empty";
    public float s2unlocks = 0.1f;
    //save preview variables slot3
    public int s3Shipselector;
    public int s3clears=0;
    public string s3name="Empty";
    public float s3unlocks = 0.1f;
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
    
    private void Start()
    {


    }


}
