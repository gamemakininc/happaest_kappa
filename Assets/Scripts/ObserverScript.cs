using UnityEngine;

public class ObserverScript : MonoBehaviour
{
    public static ObserverScript Instance { get; private set; }
    //unlocks 
    /*
      should corrispond to 'item designator'
      zero should allways be true!
      0          default unlocks(slot clears )
      1-3,7-9    shields
      4-6,10-12  health
      13-18      speed mods
      19-24      fire rate mods
      25-27      missiles
      28-35      ships (last two should have spechal unlock conditions)
      36         guns (should be last unlock)
    */
    public bool[] unlocks;
    //player output from fitting system
    public float efireRate;//fire rate for blasma weapons
    public float fireRate;//fire rate for cannons
    public int pBulletSelector;//could be reworked
    public float pSpeed;//minovering speed
    public float pHealth;//health
    public float pShield;//another health bar to go over your health so you can heal while you heal
    public float pSRegen;//shield repair rate
    public float pRepair;//health repair rate
    public int mslBonus;//adds missiles above default at level start
    //0-4 high slots, 5-9 low slots, 10-11 payload, 12 gun , 13 ship
    //value of 0 for empty slot
    public int[] fitSetup;//holds variables for fitting system
    public float[] wgBookmarks;
    public float[] pgBookmarks;

    //save for player payload slot0-1
    public int pP0;//whats in missile slot 1
    public int pP1;//ditto
    //misc savegame variables
    public int diff;//int to carry difficulty level to level
    public int levelsCleared;//stores ##of win conditions collected
    public string playerName;//stores current player name
    public int score;
    //swap vars
    public bool bookmark0;//event system any event triggered this rotation
    public bool bookmark1;//event system fitting system event triggered
    public bool bookmark2;//event system briefing room event triggered
    public bool bookmark3;//event system mission interupt event triggered
    public int esSwap;//a swap int used by the event system for mission interupt event
    public int mProgressMissile;//hold the current place on missile mission line
    public int mProgressShip;//hold the current place on ship unlock missions.
    public string missionType;//hold the type of mission to start 

    //save preview variables slot1
    public int s1diff;
    public int s1Shipselector;
    public int s1clears=0;
    public string s1name="Empty";
    public float s1unlocks=0.1f;
    //save preview variables slot2
    public int s2diff;
    public int s2Shipselector;
    public int s2clears=0;
    public string s2name="Empty";
    public float s2unlocks = 0.1f;
    //save preview variables slot3
    public int s3diff;
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
    public void setfighter() { missionType = ("combat()"); }
    public void setCapital() { missionType = ("SampleScene()"); }
    public void setStation() { missionType = ("briefing()"); }
    private void Start()
    {


    }


}
