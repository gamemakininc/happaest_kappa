using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWavev2 : MonoBehaviour
{
    public int waveCount; //Number of waves
    public int eliteWaves; //Elite waves are more difficult
        private int remainingWaves;
        private int remainingElites;
    public GameObject Boss;
        private GameObject _Boss;
    private GameObject bossTile;

    [Space(10)]
    [Header("Tiles")]
    [HideInInspector]
    public GameObject currentTile;
    private GameObject previousTile;
    public GameObject[] tilePool;
    public GameObject[] elitePool;
        private List<GameObject> _tilePool;
        private List<GameObject> _elitePool;

    private float cameraBoundX;
    private float tileEdgeX;
    private GameObject _selectedWave;

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
        remainingWaves = waveCount;
        remainingElites = eliteWaves;
        _Boss = Boss;
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

        switch (currentState) //States
        {
            case states.spawning:
                float xDif = tileEdgeX - cameraBoundX; //The distance between the camera's right border and the right edge of the tile
                //Debug.Log("xDif = " + xDif);
                if(xDif < float.Epsilon)
                {
                    if (remainingWaves == 0 && remainingElites == 0)
                    {
                        currentState = states.boss;
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
                    float xDif2 = tileEdgeX - cameraBoundX;
                    Instantiate(_Boss, new Vector2(cameraBoundX + xDif2, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f));
                    _Boss = null;
                }
                else
                {
                    currentState = states.win;
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
        //Currently 20% chance of elite wave, 80% chance of normal wave
        float waveWeight = Random.Range(0.0f, 1.0f);
        
        while(waveWeight > .89f && remainingElites <= 0 || waveWeight < .89f && remainingWaves <= 0)
            waveWeight = Random.Range(0.0f, 1.0f);
        
        if (waveWeight > .89f)
        {
            selectedWave = _elitePool[Mathf.RoundToInt(Random.Range(0.0f, _elitePool.Count - 1))];
            while(selectedWave == previousTile)
                selectedWave = _elitePool[Mathf.RoundToInt(Random.Range(0.0f, _elitePool.Count - 1))];
            remainingElites--;
        } else
        {
            selectedWave = _tilePool[Mathf.RoundToInt(Random.Range(0.0f, _tilePool.Count - 1))];
            while (selectedWave == previousTile)
                selectedWave = _tilePool[Mathf.RoundToInt(Random.Range(0.0f, _tilePool.Count - 1))];
            remainingWaves--;
        }
        
        previousTile = selectedWave;
        return;
    }

    void OnLevelComplete() //Runs when currentState = states.win
    {
        Debug.Log("Level Complete");
        ObserverScript.Instance.bookmark0 = false;
        ObserverScript.Instance.bookmark1 = false;
        ObserverScript.Instance.bookmark2 = false;
        Camera.main.GetComponent<sceneManager>().briefing();
        currentState = states.paused;
    }
}
