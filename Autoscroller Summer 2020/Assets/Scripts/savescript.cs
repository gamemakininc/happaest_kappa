using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[RequireComponent(typeof(ObserverScript))]
public class savescript : MonoBehaviour
{
    private ObserverScript gameData;
    private string savePath;
    public int saveSlot;
    public int swapint;
    private int[] swapIntArray;

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
            ObserverScript.Instance.s3Shipselector=swapint;
            ObserverScript.Instance.s3clears = save.levelsCleared;
            ObserverScript.Instance.s3name = save.playerName;
        }
    }
}
