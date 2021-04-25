using UnityEngine;

public class ObserverScript : MonoBehaviour
{
    public static ObserverScript Instance { get; private set; }
    public int deaths;
    public int cycles;
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
    //misc savegame variables
    //diff 0=NG+ 1=easy 2=normal 3=hard
    public int diff;//int to carry difficulty 0=NG+ 1=ez 2=med 3=hard
    public int levelsCleared;//stores ##of win conditions collected
    public int type1;//amount of type 1 missions done(fighter)
    public int type2;//amount of type 2 missions done(boss)
    public int type3;//amount of type 3 missions done(static boss)
    public string playerName;//stores current player name
    public int score;//total score
    public int levelScore;//score gained in current level
    //swap vars
    public bool bookmark0;//event system any event triggered this rotation
    public bool bookmark1;//event system fitting system event triggered
    public bool bookmark2;//event system briefing room event triggered
    public bool bookmark3;//event system mission interupt event triggered
    public int esSwap;//a swap int used by the event system for mission interupt event
    public int mProgressMissile;//missile mission 
    /*
     * 0 not started
     * 1 first in progress (esSwap1)
     * 2 first failed      (esSwap2)
     * 3 first complete
     * 4 second started    (esSwap3)
     * 5 second complete
     * 6 third started     (esSwap4)
     */
    public int mProgressShip;//hold the current place on ship unlock missions.
    /*
     * 0 not started
     * 1 phase1 (start)        (esSwap5)
     * 2 phase1 (done)
     * 3 phase2 (start)        (esSwap6)
     * 4 phase2 (done)
     * 5 ship2 phase1(start)   (esSwap7)
     * 6 ship2 phase1(done)ect... (8,9,10)
     */
    public int missionType;//hold the type of mission to start 0=fighter 1=boss ship 2=static boss
    public int factionId;//enemy fighters use this to select sprite
    public int factionRangeSwap;//how long between faction change
    public bool defenceMission;//used to change specific mechanics in defence missions
    //defence mission should never be missionType 2
    public int shipswap;//swap used by event system to unlock ships every few levels
    public bool poped;
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

    //settings (global save file)
    public float mvol;//hold value of music maximum volume
    public float sfxvol;//hold value for maximum sfx volume
    public bool mouseAiming;//hopefully this one is obvious
    public bool fs;//fullscreen toggle
    /*
    key map
    0  player left
    1  player up
    2  player down
    3  player right

    4  fire1
    5  fire2
    6  fire3

    7  crosshair left
    8  crosshair up
    9 crosshair down
    10 crosshair right

    11 blink
    12 bomb 
     */
    public KeyCode[] keybinds;
    public bool ngp;//unlocks new game plus
    public int resoSelect;//store set resolution

    private void Awake()
    {//awake triggers before start
        if (Instance == null)
        {//check for other observer scripts
            //??
            Instance = this;
            //if no ither found set this to a percistant game object
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            //if other instance found clear this game object
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        GetComponent<savescript>().loadSettings();

    }
    public void factionChange() 
    {
        if (factionId == 0 && factionRangeSwap >= levelsCleared) 
        {
            //incriment factionID
            factionId++;
            //add levels to new faction swap
            switch (diff) 
            {
                case 0:
                    //if ng+ add 20-50 till next faction swap
                    factionRangeSwap += Random.Range(20, 50);
                    break;
                case 1:
                    //if easy add 10-20 till next faction swap
                    factionRangeSwap += Random.Range(10, 20);
                    break;
                case 2:
                    //if medium add 20-35 till next faction change
                    factionRangeSwap += Random.Range(20, 35);
                    break;
                case 3:
                    //if hard add 30-50 to next faction change
                    factionRangeSwap += Random.Range(30, 50);
                    break;
            }
            
        }
        else if (factionId == 1 && factionRangeSwap >= levelsCleared)
        {
            //incriment factionID
            factionId++;
            //add levels to new faction swap
            switch (diff)
            {
                case 0:
                    //if ng+ add 20-50 till next faction swap
                    factionRangeSwap += Random.Range(20, 50);
                    break;
                case 1:
                    //if easy add 10-20 till next faction swap
                    factionRangeSwap += Random.Range(10, 20);
                    break;
                case 2:
                    //if medium add 20-35 till next faction change
                    factionRangeSwap += Random.Range(20, 35);
                    break;
                case 3:
                    //if hard add 30-50 to next faction change
                    factionRangeSwap += Random.Range(30, 50);
                    break;
            }
        }
        else if (factionId == 2 && factionRangeSwap >= levelsCleared) 
        {
            //incriment factionID
            factionId++;
            //add levels to new faction swap
            switch (diff)
            {
                case 0:
                    //if ng+ add 20-50 till next faction swap
                    factionRangeSwap += Random.Range(20, 50);
                    break;
                case 1:
                    //if easy add 10-20 till next faction swap
                    factionRangeSwap += Random.Range(10, 20);
                    break;
                case 2:
                    //if medium add 20-35 till next faction change
                    factionRangeSwap += Random.Range(20, 35);
                    break;
                case 3:
                    //if hard add 30-50 to next faction change
                    factionRangeSwap += Random.Range(30, 50);
                    break;
            }
        }
        else if (factionId == 3 && factionRangeSwap >= levelsCleared)
        {

            //reset faction 
            factionId = 0;
            //add levels to new faction swap
            switch (diff)
            {
                case 0:
                    //if ng+ add 20-50 till next faction swap
                    factionRangeSwap += Random.Range(20, 50);
                    break;
                case 1:
                    //if easy add 10-20 till next faction swap
                    factionRangeSwap += Random.Range(10, 20);
                    break;
                case 2:
                    //if medium add 20-35 till next faction change
                    factionRangeSwap += Random.Range(20, 35);
                    break;
                case 3:
                    //if hard add 30-50 to next faction change
                    factionRangeSwap += Random.Range(30, 50);
                    break;
            }
            FindObjectOfType<sceneManager>().cycleEnd();
        }

    }
    public void clearFitting() 
    {
        //clear active fittings
        fitSetup[0] = 0;
        fitSetup[1] = 0;
        fitSetup[2] = 0;
        fitSetup[3] = 0;
        fitSetup[4] = 0;
        fitSetup[5] = 0;
        fitSetup[6] = 0;
        fitSetup[7] = 0;
        fitSetup[8] = 0;
        fitSetup[9] = 0;
        fitSetup[10] = 0;
        fitSetup[11] = 0;
        fitSetup[12] = 0;
        fitSetup[13] = 0;
        //clear fitting bookmarks
        wgBookmarks[0] = 0;
        wgBookmarks[1] = 0;
        wgBookmarks[2] = 0;
        wgBookmarks[3] = 0;
        wgBookmarks[4] = 0;
        wgBookmarks[5] = 0;
        wgBookmarks[6] = 0;
        wgBookmarks[7] = 0;
        wgBookmarks[8] = 0;
        wgBookmarks[9] = 0;
        wgBookmarks[10] = 0;
        wgBookmarks[11] = 0;
        wgBookmarks[12] = 0;
        pgBookmarks[0] = 0;
        pgBookmarks[1] = 0;
        pgBookmarks[2] = 0;
        pgBookmarks[3] = 0;
        pgBookmarks[4] = 0;
        pgBookmarks[5] = 0;
        pgBookmarks[6] = 0;
        pgBookmarks[7] = 0;
        pgBookmarks[8] = 0;
        pgBookmarks[9] = 0;
        pgBookmarks[10] = 0;
        pgBookmarks[11] = 0;
        pgBookmarks[12] = 0;
    }
    public void hardReset() 
    {
        //lock ALL the things
        unlocks[1] = false;
        unlocks[2] = false;
        unlocks[3] = false;
        unlocks[4] = false;
        unlocks[5] = false;
        unlocks[6] = false;
        unlocks[7] = false;
        unlocks[8] = false;
        unlocks[9] = false;
        unlocks[10] = false;
        unlocks[11] = false;
        unlocks[12] = false;
        unlocks[13] = false;
        unlocks[14] = false;
        unlocks[15] = false;
        unlocks[16] = false;
        unlocks[17] = false;
        unlocks[18] = false;
        unlocks[19] = false;
        unlocks[20] = false;
        unlocks[21] = false;
        unlocks[22] = false;
        unlocks[23] = false;
        unlocks[24] = false;
        unlocks[25] = false;
        unlocks[26] = false;
        unlocks[27] = false;
        unlocks[28] = false;
        unlocks[29] = false;
        unlocks[30] = false;
        unlocks[31] = false;
        unlocks[32] = false;
        unlocks[33] = false;
        unlocks[34] = false;
        unlocks[35] = false;
        unlocks[36] = false;
        //reset mission progress markers lvl completion holders
        mProgressShip = 0;
        mProgressMissile = 0;
        levelsCleared = 0;
        type1 = 0;
        type2 = 0;
        type3 = 0;
        //because nesting functions is a good idea
        clearFitting();
    }

}
