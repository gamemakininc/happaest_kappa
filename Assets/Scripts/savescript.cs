using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[RequireComponent(typeof(ObserverScript))]
public class savescript : MonoBehaviour
{
    private float fr;
    private float efr;
    private int counter;
    private ObserverScript gameData;
    private string savePath;
    public int saveSlot;
    public int swapint;
    public float swapfloat;
    private int[] swapIntArray;
    public bool[] swapBArray;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GetComponent<ObserverScript>();
        setPlaceMats();
    }
    public void saveS1() 
    {
        savePath = Application.persistentDataPath + "savegame1.save";
        var save = new saves()
        {
            efr = ObserverScript.Instance.efireRate,
            fr = ObserverScript.Instance.fireRate,
            fitSetup = ObserverScript.Instance.fitSetup,
            pShield = ObserverScript.Instance.pShield,
            pSRegen = ObserverScript.Instance.pSRegen,
            pHealth = ObserverScript.Instance.pHealth,
            pRepair = ObserverScript.Instance.pRepair,
            pSpeed = ObserverScript.Instance.pSpeed,
            pBulletSelector = ObserverScript.Instance.pBulletSelector,
            pP0 = ObserverScript.Instance.pP0,
            pP1 = ObserverScript.Instance.pP1,
            mslBonus = ObserverScript.Instance.mslBonus,
            unlocks = ObserverScript.Instance.unlocks,
            levelsCleared = ObserverScript.Instance.levelsCleared,
            playerName = ObserverScript.Instance.playerName,
        };
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
            {
                binaryFormatter.Serialize(fileStream, save);
            }
            Debug.Log("data saved slot1");
    }

    public void saveS2()
    {
        savePath = Application.persistentDataPath + "savegame2.save";
        var save = new saves()
        {
            efr = ObserverScript.Instance.efireRate,
            fr = ObserverScript.Instance.fireRate,
            fitSetup = ObserverScript.Instance.fitSetup,
            pShield = ObserverScript.Instance.pShield,
            pSRegen = ObserverScript.Instance.pSRegen,
            pHealth = ObserverScript.Instance.pHealth,
            pRepair = ObserverScript.Instance.pRepair,
            pSpeed = ObserverScript.Instance.pSpeed,
            pBulletSelector = ObserverScript.Instance.pBulletSelector,
            pP0 = ObserverScript.Instance.pP0,
            pP1 = ObserverScript.Instance.pP1,
            mslBonus = ObserverScript.Instance.mslBonus,
            unlocks = ObserverScript.Instance.unlocks,
            levelsCleared = ObserverScript.Instance.levelsCleared,
            playerName = ObserverScript.Instance.playerName,
        };
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
        Debug.Log("data saved slot2");
    }

    public void saveS3()
    {
        savePath = Application.persistentDataPath + "savegame3.save";
        var save = new saves()
        {
            efr = ObserverScript.Instance.efireRate,
            fr = ObserverScript.Instance.fireRate,
            fitSetup = ObserverScript.Instance.fitSetup,
            pShield = ObserverScript.Instance.pShield,
            pSRegen = ObserverScript.Instance.pSRegen,
            pHealth = ObserverScript.Instance.pHealth,
            pRepair = ObserverScript.Instance.pRepair,
            pSpeed = ObserverScript.Instance.pSpeed,
            pBulletSelector = ObserverScript.Instance.pBulletSelector,
            pP0 = ObserverScript.Instance.pP0,
            pP1 = ObserverScript.Instance.pP1,
            mslBonus = ObserverScript.Instance.mslBonus,
            unlocks = ObserverScript.Instance.unlocks,
            levelsCleared = ObserverScript.Instance.levelsCleared,
            playerName = ObserverScript.Instance.playerName,
        };
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
        Debug.Log("data saved slot3");
    }
    public void loadS1() 
    {
        savePath = Application.persistentDataPath + "savegame1.save";
        if (File.Exists(savePath))
        {
            saves save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (saves)binaryFormatter.Deserialize(fileStream);
            }
            ObserverScript.Instance.efireRate = efr;
            ObserverScript.Instance.fireRate = fr;
            ObserverScript.Instance.fitSetup = save.fitSetup;
            ObserverScript.Instance.pShield = save.pShield;
            ObserverScript.Instance.pSRegen = save.pSRegen;
            ObserverScript.Instance.pHealth = save.pHealth;
            ObserverScript.Instance.pRepair = save.pRepair;
            ObserverScript.Instance.pSpeed = save.pSpeed;
            ObserverScript.Instance.pBulletSelector = save.pBulletSelector;
            ObserverScript.Instance.pP0 = save.pP0;
            ObserverScript.Instance.pP1 = save.pP1;
            ObserverScript.Instance.mslBonus = save.mslBonus;
            ObserverScript.Instance.unlocks = save.unlocks;
            ObserverScript.Instance.levelsCleared = save.levelsCleared;
            ObserverScript.Instance.playerName = save.playerName;

            Debug.Log("data loaded slot1");
            // update save info in observer
            setPlaceMats();
        }
        else 
        {
            Debug.LogWarning("save slot1 non existant");
        }

        
    }

    public void loadS2()
    {
        savePath = Application.persistentDataPath + "savegame2.save";
        if (File.Exists(savePath))
        {
            saves save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (saves)binaryFormatter.Deserialize(fileStream);
            }
            ObserverScript.Instance.efireRate = efr;
            ObserverScript.Instance.fireRate = fr;
            ObserverScript.Instance.fitSetup = save.fitSetup;
            ObserverScript.Instance.pShield = save.pShield;
            ObserverScript.Instance.pSRegen = save.pSRegen;
            ObserverScript.Instance.pHealth = save.pHealth;
            ObserverScript.Instance.pRepair = save.pRepair;
            ObserverScript.Instance.pSpeed = save.pSpeed;
            ObserverScript.Instance.pBulletSelector = save.pBulletSelector;
            ObserverScript.Instance.pP0 = save.pP0;
            ObserverScript.Instance.pP1 = save.pP1;
            ObserverScript.Instance.mslBonus = save.mslBonus;
            ObserverScript.Instance.unlocks = save.unlocks;
            ObserverScript.Instance.levelsCleared = save.levelsCleared;
            ObserverScript.Instance.playerName = save.playerName;

            Debug.Log("data loaded slot2");
            // update save info in observer
            setPlaceMats();
        }
        else
        {
            Debug.LogWarning("save slot1 non existant");
        }

    }
    public void loadS3()
    {
        savePath = Application.persistentDataPath + "savegame3.save";
        if (File.Exists(savePath))
        {
            saves save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (saves)binaryFormatter.Deserialize(fileStream);
            }
            ObserverScript.Instance.efireRate = efr;
            ObserverScript.Instance.fireRate = fr;
            ObserverScript.Instance.fitSetup = save.fitSetup;
            ObserverScript.Instance.pShield = save.pShield;
            ObserverScript.Instance.pSRegen = save.pSRegen;
            ObserverScript.Instance.pHealth = save.pHealth;
            ObserverScript.Instance.pRepair = save.pRepair;
            ObserverScript.Instance.pSpeed = save.pSpeed;
            ObserverScript.Instance.pBulletSelector = save.pBulletSelector;
            ObserverScript.Instance.pP0 = save.pP0;
            ObserverScript.Instance.pP1 = save.pP1;
            ObserverScript.Instance.mslBonus = save.mslBonus;
            ObserverScript.Instance.unlocks = save.unlocks;
            ObserverScript.Instance.levelsCleared = save.levelsCleared;
            ObserverScript.Instance.playerName = save.playerName;

            Debug.Log("data loaded slot3");
            // update save info in observer
            setPlaceMats();
        }
        else
        {
            Debug.LogWarning("save slot1 non existant");
        }
    }
    public void setPlaceMats() 
    {
        savePath = Application.persistentDataPath + "savegame1.save";
        if (File.Exists(savePath))
        {
            saves save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (saves)binaryFormatter.Deserialize(fileStream);
            }
            swapIntArray = save.fitSetup;
            swapint = swapIntArray[13];
            ObserverScript.Instance.s1Shipselector = swapint;
            ObserverScript.Instance.s1clears = save.levelsCleared;
            ObserverScript.Instance.s1name = save.playerName;
            swapBArray = save.unlocks;
            //clear counter and swapint
            counter = 0;
            swapint = 0;
            //loop to collect number of true bool
            //while (swapint <= 36)
            //{
                if (swapBArray[0] == true) { swapint += 1; }
                counter++;
            if (swapBArray[1] == true) { swapint += 1; }
            counter++;
            if (swapBArray[2] == true) { swapint += 1; }
            counter++;
            if (swapBArray[3] == true) { swapint += 1; }
            counter++;
            if (swapBArray[4] == true) { swapint += 1; }
            counter++;
            if (swapBArray[5] == true) { swapint += 1; }
            counter++;
            if (swapBArray[6] == true) { swapint += 1; }
            counter++;
            if (swapBArray[7] == true) { swapint += 1; }
            counter++;
            if (swapBArray[8] == true) { swapint += 1; }
            counter++;
            if (swapBArray[9] == true) { swapint += 1; }
            counter++;
            if (swapBArray[10] == true) { swapint += 1; }
            counter++;
            if (swapBArray[11] == true) { swapint += 1; }
            counter++;
            if (swapBArray[12] == true) { swapint += 1; }
            counter++;
            if (swapBArray[13] == true) { swapint += 1; }
            counter++;
            if (swapBArray[14] == true) { swapint += 1; }
            counter++;
            if (swapBArray[15] == true) { swapint += 1; }
            counter++;
            if (swapBArray[16] == true) { swapint += 1; }
            counter++;
            if (swapBArray[17] == true) { swapint += 1; }
            counter++;
            if (swapBArray[18] == true) { swapint += 1; }
            counter++;
            if (swapBArray[19] == true) { swapint += 1; }
            counter++;
            if (swapBArray[20] == true) { swapint += 1; }
            counter++;
            if (swapBArray[21] == true) { swapint += 1; }
            counter++;
            if (swapBArray[22] == true) { swapint += 1; }
            counter++;
            if (swapBArray[23] == true) { swapint += 1; }
            counter++;
            if (swapBArray[24] == true) { swapint += 1; }
            counter++;
            if (swapBArray[25] == true) { swapint += 1; }
            counter++;
            if (swapBArray[26] == true) { swapint += 1; }
            counter++;
            if (swapBArray[27] == true) { swapint += 1; }
            counter++;
            if (swapBArray[28] == true) { swapint += 1; }
            counter++;
            if (swapBArray[29] == true) { swapint += 1; }
            counter++;
            if (swapBArray[30] == true) { swapint += 1; }
            counter++;
            if (swapBArray[31] == true) { swapint += 1; }
            counter++;
            if (swapBArray[32] == true) { swapint += 1; }
            counter++;
            if (swapBArray[33] == true) { swapint += 1; }
            counter++;
            if (swapBArray[34] == true) { swapint += 1; }
            counter++;
            if (swapBArray[35] == true) { swapint += 1; }
            counter++;
            if (swapBArray[36] == true) { swapint += 1; }
            counter++;
            //}

            //output to observer
            ObserverScript.Instance.s1unlocks = swapint;
        }
        savePath = Application.persistentDataPath + "savegame2.save";
        if (File.Exists(savePath))
        {
            saves save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (saves)binaryFormatter.Deserialize(fileStream);
            }
            swapIntArray = save.fitSetup;
            swapint = swapIntArray[13];
            ObserverScript.Instance.s2Shipselector = swapint;
            ObserverScript.Instance.s2clears = save.levelsCleared;
            ObserverScript.Instance.s2name = save.playerName;
            //clear counter and swapint
            counter = 0;
            swapint = 0;
            //loop to collect number of true bool
            while (swapint <= 35)
            {
                if (swapBArray[counter] == true) { swapint += 1; }
                Debug.Log(counter);
                counter++;
            }
            //output to observer
            ObserverScript.Instance.s2unlocks = swapint;

        }

        savePath = Application.persistentDataPath + "savegame3.save";
        if (File.Exists(savePath))
        {
            saves save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (saves)binaryFormatter.Deserialize(fileStream);
            }
            swapIntArray = save.fitSetup;
            swapint = swapIntArray[13];
            ObserverScript.Instance.s3Shipselector = swapint;
            ObserverScript.Instance.s3clears = save.levelsCleared;
            ObserverScript.Instance.s3name = save.playerName;
            //clear counter and swapint
            counter = 0;
            swapint = 0;
            //loop to collect number of true bool
            while (swapint <= 35)
            {
                if (swapBArray[counter] == true) { swapint += 1; }
                counter++;
            }

            //output to observer
            ObserverScript.Instance.s3unlocks = swapint;
        }
    }
}
