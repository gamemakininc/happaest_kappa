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
            unlocks = ObserverScript.Instance.unlocks,
            efr = ObserverScript.Instance.efireRate,
            fr = ObserverScript.Instance.fireRate,
            pBulletSelector = ObserverScript.Instance.pBulletSelector,
            pSpeed = ObserverScript.Instance.pSpeed,
            pHealth = ObserverScript.Instance.pHealth,
            pShield = ObserverScript.Instance.pShield,
            pSRegen = ObserverScript.Instance.pSRegen,
            pRepair = ObserverScript.Instance.pRepair,
            mslBonus = ObserverScript.Instance.mslBonus,
            fitSetup = ObserverScript.Instance.fitSetup,
            wgBookmarks = ObserverScript.Instance.wgBookmarks,
            pgBookmarks = ObserverScript.Instance.pgBookmarks,
            pP0 = ObserverScript.Instance.pP0,
            pP1 = ObserverScript.Instance.pP1,
            diff = ObserverScript.Instance.diff,
            levelsCleared = ObserverScript.Instance.levelsCleared,
            playerName = ObserverScript.Instance.playerName,
            score = ObserverScript.Instance.score,
            levelScore = ObserverScript.Instance.levelScore,

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
            unlocks = ObserverScript.Instance.unlocks,
            efr = ObserverScript.Instance.efireRate,
            fr = ObserverScript.Instance.fireRate,
            pBulletSelector = ObserverScript.Instance.pBulletSelector,
            pSpeed = ObserverScript.Instance.pSpeed,
            pHealth = ObserverScript.Instance.pHealth,
            pShield = ObserverScript.Instance.pShield,
            pSRegen = ObserverScript.Instance.pSRegen,
            pRepair = ObserverScript.Instance.pRepair,
            mslBonus = ObserverScript.Instance.mslBonus,
            fitSetup = ObserverScript.Instance.fitSetup,
            wgBookmarks = ObserverScript.Instance.wgBookmarks,
            pgBookmarks = ObserverScript.Instance.pgBookmarks,
            pP0 = ObserverScript.Instance.pP0,
            pP1 = ObserverScript.Instance.pP1,
            diff = ObserverScript.Instance.diff,
            levelsCleared = ObserverScript.Instance.levelsCleared,
            playerName = ObserverScript.Instance.playerName,
            score = ObserverScript.Instance.score,
            levelScore = ObserverScript.Instance.levelScore,
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
            unlocks = ObserverScript.Instance.unlocks,
            efr = ObserverScript.Instance.efireRate,
            fr = ObserverScript.Instance.fireRate,
            pBulletSelector = ObserverScript.Instance.pBulletSelector,
            pSpeed = ObserverScript.Instance.pSpeed,
            pHealth = ObserverScript.Instance.pHealth,
            pShield = ObserverScript.Instance.pShield,
            pSRegen = ObserverScript.Instance.pSRegen,
            pRepair = ObserverScript.Instance.pRepair,
            mslBonus = ObserverScript.Instance.mslBonus,
            fitSetup = ObserverScript.Instance.fitSetup,
            wgBookmarks = ObserverScript.Instance.wgBookmarks,
            pgBookmarks = ObserverScript.Instance.pgBookmarks,
            pP0 = ObserverScript.Instance.pP0,
            pP1 = ObserverScript.Instance.pP1,
            diff = ObserverScript.Instance.diff,
            levelsCleared = ObserverScript.Instance.levelsCleared,
            playerName = ObserverScript.Instance.playerName,
            score = ObserverScript.Instance.score,
            levelScore = ObserverScript.Instance.levelScore,
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
            ObserverScript.Instance.unlocks = save.unlocks;
            ObserverScript.Instance.efireRate = save.efr;
            ObserverScript.Instance.fireRate = save.fr;
            ObserverScript.Instance.pBulletSelector = save.pBulletSelector;
            ObserverScript.Instance.pSpeed = save.pSpeed;
            ObserverScript.Instance.pHealth = save.pHealth;
            ObserverScript.Instance.pShield = save.pShield;
            ObserverScript.Instance.pSRegen = save.pSRegen;
            ObserverScript.Instance.pRepair = save.pRepair;
            ObserverScript.Instance.mslBonus = save.mslBonus;
            ObserverScript.Instance.fitSetup = save.fitSetup;
            ObserverScript.Instance.wgBookmarks = save.wgBookmarks;
            ObserverScript.Instance.pgBookmarks = save.pgBookmarks;
            ObserverScript.Instance.pP0 = save.pP0;
            ObserverScript.Instance.pP1 = save.pP1;
            ObserverScript.Instance.diff = save.diff;
            ObserverScript.Instance.levelsCleared = save.levelsCleared;
            ObserverScript.Instance.playerName = save.playerName;
            ObserverScript.Instance.score = save.score;
            ObserverScript.Instance.levelScore = save.levelScore;
           

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
            ObserverScript.Instance.unlocks = save.unlocks;
            ObserverScript.Instance.efireRate = save.efr;
            ObserverScript.Instance.fireRate = save.fr;
            ObserverScript.Instance.pBulletSelector = save.pBulletSelector;
            ObserverScript.Instance.pSpeed = save.pSpeed;
            ObserverScript.Instance.pHealth = save.pHealth;
            ObserverScript.Instance.pShield = save.pShield;
            ObserverScript.Instance.pSRegen = save.pSRegen;
            ObserverScript.Instance.pRepair = save.pRepair;
            ObserverScript.Instance.mslBonus = save.mslBonus;
            ObserverScript.Instance.fitSetup = save.fitSetup;
            ObserverScript.Instance.wgBookmarks = save.wgBookmarks;
            ObserverScript.Instance.pgBookmarks = save.pgBookmarks;
            ObserverScript.Instance.pP0 = save.pP0;
            ObserverScript.Instance.pP1 = save.pP1;
            ObserverScript.Instance.diff = save.diff;
            ObserverScript.Instance.levelsCleared = save.levelsCleared;
            ObserverScript.Instance.playerName = save.playerName;
            ObserverScript.Instance.score = save.score;
            ObserverScript.Instance.levelScore = save.levelScore;

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
            ObserverScript.Instance.unlocks = save.unlocks;
            ObserverScript.Instance.efireRate = save.efr;
            ObserverScript.Instance.fireRate = save.fr;
            ObserverScript.Instance.pBulletSelector = save.pBulletSelector;
            ObserverScript.Instance.pSpeed = save.pSpeed;
            ObserverScript.Instance.pHealth = save.pHealth;
            ObserverScript.Instance.pShield = save.pShield;
            ObserverScript.Instance.pSRegen = save.pSRegen;
            ObserverScript.Instance.pRepair = save.pRepair;
            ObserverScript.Instance.mslBonus = save.mslBonus;
            ObserverScript.Instance.fitSetup = save.fitSetup;
            ObserverScript.Instance.wgBookmarks = save.wgBookmarks;
            ObserverScript.Instance.pgBookmarks = save.pgBookmarks;
            ObserverScript.Instance.pP0 = save.pP0;
            ObserverScript.Instance.pP1 = save.pP1;
            ObserverScript.Instance.diff = save.diff;
            ObserverScript.Instance.levelsCleared = save.levelsCleared;
            ObserverScript.Instance.playerName = save.playerName;
            ObserverScript.Instance.score = save.score;
            ObserverScript.Instance.levelScore = save.levelScore;

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
            ObserverScript.Instance.s1diff = save.diff;
            ObserverScript.Instance.s1Shipselector = swapint;
            ObserverScript.Instance.s1clears = save.levelsCleared;
            ObserverScript.Instance.s1name = save.playerName;
            swapBArray = save.unlocks;
            //clear counter and swapint
            counter = 0;
            swapint = 0;
            //loop to collect number of true bool
            while (counter <= 36)
            {
                if (swapBArray[counter] == true) { swapint += 1; }
                counter++;
            }

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
            ObserverScript.Instance.s2diff = save.diff;
            ObserverScript.Instance.s2Shipselector = swapint;
            ObserverScript.Instance.s2clears = save.levelsCleared;
            ObserverScript.Instance.s2name = save.playerName;
            swapBArray = save.unlocks;
            //clear counter and swapint
            counter = 0;
            swapint = 0;
            //loop to collect number of true bool
            while (counter <= 36)
            {
                if (swapBArray[counter] == true) { swapint += 1; }
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
            ObserverScript.Instance.s3diff = save.diff;
            ObserverScript.Instance.s3Shipselector = swapint;
            ObserverScript.Instance.s3clears = save.levelsCleared;
            ObserverScript.Instance.s3name = save.playerName;
            swapBArray = save.unlocks;
            //clear counter and swapint
            counter = 0;
            swapint = 0;
            //loop to collect number of true bool
            while (counter <= 36)
            {
                if (swapBArray[counter] == true) { swapint += 1; }
                counter++;
            }

            //output to observer
            ObserverScript.Instance.s3unlocks = swapint;
        }
    }
    public void saveSettings() 
    {
        savePath = Application.persistentDataPath + "settings.htm";
        var sSettings = new settings()
        {
            mvol = ObserverScript.Instance.mvol,
            sfxvol = ObserverScript.Instance.sfxvol,
            mouseAiming = ObserverScript.Instance.mouseAiming,
            keybinds = ObserverScript.Instance.keybinds,
            ngp = ObserverScript.Instance.ngp,
        };
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, sSettings);
        }
        Debug.Log("settings saved");

    }
    public void loadSettings()
    {
        savePath = Application.persistentDataPath + "settings.htm";
        if (File.Exists(savePath))
        {
            settings sSettings;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                sSettings = (settings)binaryFormatter.Deserialize(fileStream);
            }
            ObserverScript.Instance.mvol = sSettings.mvol;
            ObserverScript.Instance.sfxvol = sSettings.sfxvol;
            ObserverScript.Instance.mouseAiming = sSettings.mouseAiming;
            ObserverScript.Instance.keybinds = sSettings.keybinds;
            ObserverScript.Instance.ngp = sSettings.ngp;

            Debug.Log("settings loaded");
            // update save info in observer
            setPlaceMats();
        }
        else
        {
            Debug.LogWarning("settings save non existant");
        }
    }
}
