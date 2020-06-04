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
    private int previousTile = -1;
    public GameObject[] tilePool;
    public GameObject[] elitePool;
        private List<GameObject> _tilePool;
        private List<GameObject> _elitePool;

    private float cameraBoundX;
    private float tileEdgeX;

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
        _elitePool = new List<GameObject>(_elitePool);
        //Right border of the camera
        cameraBoundX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;

        GameObject _selectedWave;
        SelectWave(out _selectedWave);
        currentTile = Instantiate(_selectedWave, new Vector2(cameraBoundX, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f));

        currentState = states.spawning;
    }

    private void Update()
    {
        if (currentTile != null)
        {
            //The right border of the background tile
            tileEdgeX = currentTile.transform.position.x + currentTile.GetComponent<SpriteRenderer>().bounds.extents.x;
        }

        switch (currentState) //States
        {
            case states.spawning:
                float xDif = tileEdgeX - cameraBoundX; //The distance between the camera's right border and the right edge of the tile
                if(xDif < float.Epsilon)
                {
                    GameObject _selectedWave;
                    SelectWave(out _selectedWave);
                    currentTile = Instantiate(_selectedWave, Vector3.zero, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                }
                break;
            case states.paused:
                break;
            case states.boss:
                if (_Boss)
                {
                    Instantiate(_Boss, Vector3.zero, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                    _Boss = null;
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
        int totalWaves = _tilePool.Count + _elitePool.Count;
        int randNum = Mathf.RoundToInt(Random.Range(0, totalWaves));
        //prevents the same tile being used twice
        while(randNum == previousTile)
            randNum = Mathf.RoundToInt(Random.Range(0, totalWaves));
        previousTile = randNum;
        if (randNum > _tilePool.Count)
        {
            randNum -= _tilePool.Count;
            selectedWave = _elitePool[randNum];
            _elitePool.Remove(selectedWave);
            remainingElites--;
        }
        else
        {
            selectedWave = _tilePool[randNum];
            _tilePool.Remove(selectedWave);
            remainingWaves--;
        }
        return;
    }

    void OnLevelComplete() //Runs when currentState = states.win
    {
        currentState = states.paused;
    }
}
