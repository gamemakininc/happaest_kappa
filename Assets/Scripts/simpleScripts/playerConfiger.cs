using UnityEngine;

[RequireComponent(typeof(PlayerScript))]
public class playerConfiger : MonoBehaviour
{
    private PlayerScript pspsps;
    private int[] _fitsetup;
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
        _fitsetup = ObserverScript.Instance.fitSetup;
        //set playerscript hook
        pspsps = GetComponent<PlayerScript>();

        //set animater (and redundant viewmodel)
        GetComponent<Animator>().runtimeAnimatorController = animationset[_fitsetup[13] - 1];
        GetComponent<SpriteRenderer>().sprite = viewmodel[_fitsetup[13] - 1];
        //----------------------------------------------------------------------------
        //weapons
        //set missiles
        if (_fitsetup[10] > 0) //so the whole thing dosent error out if nothing fitted
        {
            pspsps.MissilePrefab1 = missiles[_fitsetup[10] - 1];
        }
        if (_fitsetup[11] > 0) //so the whole thing dosent error out if nothing fitted
        {
            pspsps.MissilePrefab2 = missiles[_fitsetup[11] - 1];
        }
        //clause to set p0 to bace missile w no ammo if bolth empty
        if (_fitsetup[10] <= 0 && _fitsetup[11] <= 0) { pspsps.MissilePrefab1 = missiles[0]; }

        //slot1 calc ammo
        if (_fitsetup[10] == 1) { p1Ammo = 20; }
        else if (_fitsetup[10] == 2) { p1Ammo = 15; }
        else if (_fitsetup[10] == 3) { p1Ammo = 10; }
        p1Ammo += ObserverScript.Instance.mslBonus;
        //send ammo var
        pspsps.payload0Ammo = p1Ammo;

        //slot2 calc ammo
        if (_fitsetup[11] == 1) { p2Ammo = 20; }
        else if (_fitsetup[11] == 2) { p2Ammo = 15; }
        else if (_fitsetup[11] == 3) { p2Ammo = 10; }
        p2Ammo += ObserverScript.Instance.mslBonus;
        //send ammo var
        pspsps.payload1Ammo = p2Ammo;

        //set gun
        //set bullet
        pspsps.BulletPrefab = bullets[_fitsetup[12] - 1];
        //set gun sound
        pspsps.sounds[0] = gunSounds[_fitsetup[12] - 1];
        //set refire rate
        switch (_fitsetup[12]) 
        {
            //no gun
            case 0:
                //should not be possible
                break;
            //single cannon
            case 1:
                pspsps.baceRefireRate = ObserverScript.Instance.fireRate;
                pspsps.nextFire = ObserverScript.Instance.fireRate;
                break;
            //twin cannon
            case 2:
                pspsps.baceRefireRate = ObserverScript.Instance.fireRate + 0.1f;
                pspsps.nextFire = ObserverScript.Instance.fireRate;
                break;
            //shrapnel cannon
            case 3:
                pspsps.baceRefireRate = ObserverScript.Instance.fireRate + 0.2f;
                pspsps.nextFire = ObserverScript.Instance.fireRate;
                break;
            //single plaz
            case 4:
                pspsps.baceRefireRate = ObserverScript.Instance.efireRate;
                pspsps.nextFire = ObserverScript.Instance.efireRate;
                break;
            //twin plaz
            case 5:
                pspsps.baceRefireRate = ObserverScript.Instance.efireRate + 0.1f;
                pspsps.nextFire = ObserverScript.Instance.efireRate;
                break;
            //triple plaz
            case 6:
                pspsps.baceRefireRate = ObserverScript.Instance.efireRate + 0.4f;
                pspsps.nextFire = ObserverScript.Instance.efireRate;
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
        pspsps.shield = pspsps.maxShield;
        //shield regen
        pspsps.sRegen = ObserverScript.Instance.pSRegen;
        //set health
        pspsps.maxHealth = ObserverScript.Instance.pHealth;
        pspsps.health = pspsps.maxHealth;
        //repair
        pspsps.repair = ObserverScript.Instance.pRepair;
        //setdeath effect 
        pspsps.deathEffect = deathEffects[_fitsetup[13] - 1];

        //-------------------------------------------------------------------------
        //sp33d
        pspsps.MoveSpeed = ObserverScript.Instance.pSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
