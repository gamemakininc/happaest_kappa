using UnityEngine;

[RequireComponent(typeof(PlayerScript))]
public class playerConfiger : MonoBehaviour
{
    private PlayerScript pspsps;
    private int[] fitsetup;
    public Sprite[] viewmodel;
    public RuntimeAnimatorController[] animationset;
    public GameObject[] bullets;
    public GameObject[] missiles;
    public AudioClip[] gunSounds;
    public GameObject[] deathEffects;
    private int p1Ammo;
    private int p2Ammo;

    // Start is called before the first frame update
    void Start()
    {
        fitsetup = ObserverScript.Instance.fitSetup;
        //set playerscript hook
        pspsps = GetComponent<PlayerScript>();

        //set animater (and redundant viewmodel)
        GetComponent<Animator>().runtimeAnimatorController = animationset[fitsetup[13] - 1];
        GetComponent<SpriteRenderer>().sprite = viewmodel[fitsetup[13] - 1];
        //----------------------------------------------------------------------------
        //weapons
        //set missiles
        if (fitsetup[10] > 0) //so the whole thing dosent error out if nothing fitted
        {
            pspsps.MissilePrefab1 = missiles[fitsetup[10] - 1];
        }
        if (fitsetup[11] > 0) //so the whole thing dosent error out if nothing fitted
        {
            pspsps.MissilePrefab2 = missiles[fitsetup[11] - 1]; 
        }
        //clause to set p0 to bace missile w no ammo if bolth empty
        if (fitsetup[10] <= 0 && fitsetup[11] <= 0) { pspsps.MissilePrefab1 = missiles[0]; }
        
        //slot1 calc ammo
        if (fitsetup[10] == 1) { p1Ammo = 20; }
        else if (fitsetup[10] == 2) { p1Ammo = 15; }
        else if (fitsetup[10] == 3) { p1Ammo = 10; }
        p1Ammo += ObserverScript.Instance.mslBonus;
        //send ammo var
        pspsps.payload0Ammo = p1Ammo;

        //slot2 calc ammo
        if (fitsetup[11]==1) { p2Ammo = 20; }
        else if (fitsetup[11] == 2) { p2Ammo = 15; }
        else if (fitsetup[11] == 3) { p2Ammo = 10; }
        p2Ammo += ObserverScript.Instance.mslBonus;
        //send ammo var
        pspsps.payload1Ammo = p2Ammo;

        //set gun
        //if dual laser set prefab to laser
        if (ObserverScript.Instance.fitSetup[12] == 8) 
        { 
            //fitsetup[12]--; 
        }
        //set bullet
        pspsps.BulletPrefab = bullets[fitsetup[12] - 1];
        //set gun sound
        pspsps.sounds[0] = gunSounds[fitsetup[12 - 1]];
        //set refire rate
        switch (fitsetup[12]) 
        {
            //no gun
            case 0:
                //do nothing
                break;
            //single cannon
            case 1:
                pspsps.baceRefireRate = ObserverScript.Instance.fireRate;
                break;
            //twin cannon
            case 2:
                pspsps.baceRefireRate = ObserverScript.Instance.fireRate + 0.1f;
                break;
            //shrapnel cannon
            case 3:
                pspsps.baceRefireRate = ObserverScript.Instance.fireRate + 0.2f;
                break;
            //single plaz
            case 4:
                pspsps.baceRefireRate = ObserverScript.Instance.efireRate;
                break;
            //twin plaz
            case 5:
                pspsps.baceRefireRate = ObserverScript.Instance.efireRate + 0.1f;
                break;
            //triple plaz
            case 6:
                pspsps.baceRefireRate = ObserverScript.Instance.efireRate + 0.4f;
                break;
            //laser1
            case 7:
                pspsps.baceRefireRate = 0;
                break;
            //laser2
            case 8:
                pspsps.baceRefireRate = 0;
                break;
        }
        //-----------------------------------------------------------------------
        //health
        //set shield
        pspsps.maxShield = ObserverScript.Instance.pShield;
        //shield regen
        pspsps.sRegen = ObserverScript.Instance.pSRegen;
        //set health
        pspsps.maxHealth = ObserverScript.Instance.pHealth;
        //repair
        pspsps.repair = ObserverScript.Instance.pRepair;
        //setdeath effect 
        pspsps.deathEffect = deathEffects[fitsetup[13] - 1];

        //-------------------------------------------------------------------------
        //sp33d
        pspsps.MoveSpeed = ObserverScript.Instance.pSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
