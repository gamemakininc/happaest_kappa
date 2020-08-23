using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyWavev2 : MonoBehaviour
{
    public GameObject[] enemyShips;
    public GameObject es;
    private bool endgame;
    public int waveCount; //Number of waves
    public int eliteWaves; //Elite waves are more difficult
    private int remainingWaves;
    private int remainingElites;
    public GameObject[] Boss;
        private GameObject _Boss;

    [Space(10)]
    [Header("Tiles")]
    [HideInInspector]
    //why are these game objects
    public GameObject currentTile;
    private GameObject previousTile;
    //??
    public GameObject[] tilePool;
    public GameObject[] elitePool;
        private List<GameObject> _tilePool;
        private List<GameObject> _elitePool;

    private float cameraBoundX;
    private float tileEdgeX;
    private GameObject _selectedWave;
    //escaped enemy swaps
    public int lostS;
    public int lostW;
    public int lostD;
    public int lostK;
    public int respawnAmt;
    public float respawnIntervol;
    bool swapbool;
    public enum states
    {
        spawning,
        paused,
        boss,
        win
    }
    private states currentState;

    void Start()
    {
        int levelCount;
        //finds current mission, and gets number of mission type clears
        if (GameObject.Find("Observer") != null)
        {
            switch (GameObject.Find("Observer").GetComponent<ObserverScript>().missionType)
            {
                case 0:
                    levelCount = GameObject.Find("Observer").GetComponent<ObserverScript>().type1;
                    break;
                case 1:
                    levelCount = GameObject.Find("Observer").GetComponent<ObserverScript>().type2;
                    break;
                case 2:
                    levelCount = GameObject.Find("Observer").GetComponent<ObserverScript>().type3;
                    break;
            }
            levelCount = GameObject.Find("Observer").GetComponent<ObserverScript>().levelsCleared;
        }
        else
            levelCount = 0; 

        //Inverse exponential scaling
        //If levels cleared is 0, then scale is 1, else sqrt(levelcount + 1)
        remainingWaves = levelCount > 0 ? Mathf.RoundToInt(waveCount * Mathf.Sqrt(levelCount + 1)) : Mathf.RoundToInt(waveCount * 1);
        remainingElites = levelCount > 0 ? Mathf.RoundToInt(eliteWaves * Mathf.Sqrt(levelCount + 1)) : Mathf.RoundToInt(eliteWaves * 1);
        if (ObserverScript.Instance.missionType > 0)
        {
            //will need rewritten when more than one boss of each type exist
            _Boss = Boss[ObserverScript.Instance.missionType - 1];
        }
        else if (ObserverScript.Instance.missionType == 0) 
        {
            _Boss = null;
        }
        _tilePool = new List<GameObject>(tilePool);
        _elitePool = new List<GameObject>(elitePool);
        //Right border of the camera
        cameraBoundX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;

        SelectWave(out _selectedWave);
        currentTile = Instantiate(_selectedWave, new Vector2(cameraBoundX, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f)).transform.GetChild(0).gameObject;

        currentState = states.spawning;

        //Debug.Log("Tile bounds.extents = " + currentTile.GetComponent<SpriteRenderer>().bounds.extents.x);
    }

    private void Update()
    {
        waveCount = remainingWaves; //Debug
        if (currentTile != null)
        {
            //The right border of the background tile
            tileEdgeX = currentTile.transform.position.x + currentTile.GetComponent<SpriteRenderer>().bounds.extents.x;
        }
        else
            tileEdgeX = 0;

        switch (currentState) //States
        {
            case states.spawning:
                if (!currentTile)
                {
                    SelectWave(out _selectedWave);
                    currentTile = Instantiate(_selectedWave, new Vector2(cameraBoundX, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f)).transform.GetChild(0).gameObject;
                }
                float xDif = tileEdgeX - cameraBoundX; //The distance between the camera's right border and the right edge of the tile
                //Debug.Log("xDif = " + xDif);
                if (xDif < float.Epsilon)
                {
                    if (remainingWaves == 0 && remainingElites == 0)
                    {
                        if (_Boss == null)
                        {
                            if (endgame == false)
                            {
                                //set pool to empty tiles only
                                //set retrigger prevention
                                endgame = true;
                                //add waves
                                remainingWaves += 4;
                                //respawn missed enemys
                                StartCoroutine(respawnMissed());

                            }
                            else if (endgame == true)
                            {
                                if (ObserverScript.Instance.missionType == 0)
                                {
                                    ObserverScript.Instance.type1++;
                                    currentState = states.win;
                                }
                            }

                        }
                        else
                        {
                            currentState = states.boss;
                        }
                        return;
                    }

                    //Debug.Log("Spawning Wave");
                    SelectWave(out _selectedWave);
                    Debug.Log(_selectedWave.name);
                    currentTile = Instantiate(_selectedWave, new Vector2(cameraBoundX + xDif, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f)).transform.GetChild(0).gameObject;
                    return;
                }
                break;
            case states.paused:
                break;
            case states.boss:
                if (_Boss)
                {
                    StartCoroutine(respawnMissed());
                    float xDif2 = tileEdgeX - cameraBoundX;
                    Instantiate(_Boss, new Vector2(cameraBoundX + xDif2, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                    _Boss = null;
                }
                else
                {
                    //currentState = states.win;
                }
                break;
            case states.win:
                OnLevelComplete();
                break;
            default:
                break;
        }
    }

    //Selects which prefab to spawn
    void SelectWave(out GameObject selectedWave) 
    {
        if (endgame == false)
        {
            //Currently 20% chance of elite wave, 80% chance of normal wave
            float waveWeight = Random.Range(0.0f, 1.0f);

            while (waveWeight > .89f && remainingElites <= 0 || waveWeight < .89f && remainingWaves <= 0)
                waveWeight = Random.Range(0.0f, 1.0f);

            if (waveWeight > .89f)
            {
                selectedWave = _elitePool[Mathf.RoundToInt(Random.Range(0.0f, _elitePool.Count - 1))];
                while (selectedWave == previousTile)
                    selectedWave = _elitePool[Mathf.RoundToInt(Random.Range(0.0f, _elitePool.Count - 1))];
                remainingElites--;
            }
            else
            {
                selectedWave = _tilePool[Mathf.RoundToInt(Random.Range(0.0f, _tilePool.Count - 1))];
                while (selectedWave == previousTile)
                    selectedWave = _tilePool[Mathf.RoundToInt(Random.Range(0.0f, _tilePool.Count - 1))];
                remainingWaves--;
            }

            previousTile = selectedWave;
            return;
        }
        else 
        {
            selectedWave = _tilePool[7]; 
            remainingWaves--;
            return;
        }
    }
    IEnumerator respawnMissed()
    {
        //wait
        yield return 0;
        yield return new WaitForSeconds(3);
        //set amt to respawn
        respawnAmt = lostS + lostW + lostD + lostK;
        //l00p to drain lvl score into total score
        while (respawnAmt>0)
        {
            int i = Random.Range(0, 3);
            if (i == 0) 
            {
                if (lostS > 0)
                {
                    //deincriment lostS && total amt to spawn
                    lostS--;
                    respawnAmt--;
                    //instantiate streaght enemy fixed x random y
                    Instantiate(enemyShips[i],new Vector3(11, Random.Range(4.6f, -4.6f), 0),Quaternion.Euler(new Vector3(0,0,90)));
                    //set swapbool
                    swapbool = true;
                }
                else 
                {
                    i = Random.Range(1, 3);
                }
            }
            if (i == 1&&swapbool==false)
            {
                if (lostW > 0)
                {
                    //deincriment lostW && total amt to spawn
                    lostW--;
                    respawnAmt--;
                    //instantiate streaght enemy fixed x random y
                    Instantiate(enemyShips[i], new Vector3(11, Random.Range(4.6f, -4.6f), 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                else
                {
                    
                }
            }
            if (i == 2)
            {
                if (lostD > 0 && swapbool == false)
                {
                    //deincriment lostD && total amt to spawn
                    lostD--;
                    respawnAmt--;
                    //instantiate streaght enemy fixed x random y
                    Instantiate(enemyShips[i], new Vector3(11, Random.Range(4.6f, -4.6f), 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                else
                {
                    i = 3;
                }
            }
            if (i == 3)
            {
                if (lostK > 0 && swapbool == false)
                {
                    //deincriment lostK && total amt to spawn
                    lostK--;
                    respawnAmt--;
                    //instantiate streaght enemy fixed x random y
                    Instantiate(enemyShips[i], new Vector3(11, Random.Range(4.6f, -4.6f), 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                //if nothing spawned this check skip RnG and just spawn something
                else if (lostS > 0)
                {
                    lostS--;
                    respawnAmt--;
                    Instantiate(enemyShips[0], new Vector3(11, Random.Range(4.6f, -4.6f), 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                else if (lostW > 0)
                {
                    lostW--;
                    respawnAmt--;
                    Instantiate(enemyShips[1], new Vector3(11, Random.Range(4.6f, -4.6f), 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                else if (lostD > 0)
                {
                    lostD--;
                    respawnAmt--;
                    Instantiate(enemyShips[2], new Vector3(11, Random.Range(4.6f, -4.6f), 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                }
            }
            //wait variable amount
            yield return 0;
            yield return new WaitForSeconds(respawnIntervol);
            //idk
            swapbool = false;
        }
    }

    public void OnLevelComplete() //Runs when currentState = states.win
    {
        Debug.Log("Level Complete");
        ObserverScript.Instance.bookmark0 = false;
        ObserverScript.Instance.bookmark1 = false;
        ObserverScript.Instance.bookmark2 = false;
        ObserverScript.Instance.bookmark3 = false;
        currentState = states.paused;
        es.GetComponent<endScreenScript>().win = true;
        es.SetActive(true);
    }
}
