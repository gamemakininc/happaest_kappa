[System.Serializable]
public class saves
{
    //player output from fitting system
    public float fr;
    public float efr;
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
}
