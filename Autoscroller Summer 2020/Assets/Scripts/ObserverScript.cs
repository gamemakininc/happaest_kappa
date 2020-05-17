using UnityEngine;

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

    //save for player payload slot0-1
    public int pP0;
    public int pP1;
    //
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


}
