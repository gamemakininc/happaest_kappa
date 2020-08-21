﻿using UnityEngine;

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
    //misc savegame variables
    //diff 0=NG+ 1=easy 2=normal 3=hard
    public int diff;//int to carry difficulty level to level
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
     * 1 first in progress
     * 2 first complete
     * 3 second started
     * ect..
     */
    public int mProgressShip;//hold the current place on ship unlock missions.
    /*
     * 0 not started
     * 1 phase1 
     * 2
     * 3
     * 4
     * 5 secrit ship 1 unlocked
     * ect...
     */
    public int missionType;//hold the type of mission to start 0=fighter 1=boss ship 2=static boss
    public int factionId;//not yet implemented
    public int factionRangeSwap;//how long between faction change
    public bool defenceMission;//used to change specific mechanics in defence missions
    //defence mission should never be missionType 2

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
        GetComponent<savescript>().loadSettings();

    }
    public void factionChange() 
    {
        if (factionId == 0 && factionRangeSwap >= levelsCleared) 
        {
            //incriment factionID
            factionId++;
            //add between 20-50 for next faction swap
            factionRangeSwap += Random.Range(20,50);
            
        }
        else if (factionId == 1 && factionRangeSwap >= levelsCleared)
        {
            //incriment factionID
            factionId++;
            //add between 20-50 for next faction swap
            factionRangeSwap += Random.Range(20, 50);
        }
        else if (factionId == 2 && factionRangeSwap >= levelsCleared) 
        {
            //reset faction 
            factionId=0;
            //add 20-50 for next faction update tick
            factionRangeSwap += Random.Range(20, 50);
        }
    }


}