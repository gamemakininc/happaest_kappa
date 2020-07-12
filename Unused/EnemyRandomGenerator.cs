using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyRandomGenerator : MonoBehaviour
{
    public int waveCount; //Number of waves
    public int eliteWaves; //Elite waves are more difficult
    private int remainingWaves;
    private int remainingElites;
    public GameObject Boss;
    private GameObject _Boss;

    [Space(10)]
    public float waveDelay = 5.0f; //Delay between waves spawning
    private float waveDelayCurrent;
    [Tooltip("Overwrites Wave Delay with prefab's wave delay")]
    //public bool overwriteDelay;

    [Space(10)]
    [Header("Wave Pools")] //Options for the script to spawn waves from
    public GameObject[] wavePool;
    public GameObject[] elitePool;
    private List<GameObject> _wavePool;
    private List<GameObject> _elitePool;

    private bool isPaused;

    public enum states{
        spawning,
        paused,
        boss,
        win
    }
    private states currentState;

    private void Start()
    {
        waveDelayCurrent = waveDelay;
        _wavePool = new List<GameObject>(wavePool);
        _elitePool = new List<GameObject>(elitePool);
        remainingWaves = waveCount;
        remainingElites = eliteWaves;
        _Boss = Boss;

        currentState = states.spawning;
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case states.spawning:
                if(waveCount == 0 && eliteWaves == 0)
                {
                    currentState = states.boss;
                    return;
                }
                if (!Mathf.Approximately(waveDelayCurrent, 0.0f))
                {
                    waveDelayCurrent -= Time.deltaTime;
                } else
                {
                    GameObject _selectedWave;
                    SelectWave(out _selectedWave);
                    Instantiate(_selectedWave, Vector3.zero, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                    waveDelayCurrent = waveDelay;
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

    void SelectWave(out GameObject selectedWave)
    {
        int totalWaves = _wavePool.Count + _elitePool.Count;
        int randNum = Mathf.RoundToInt(Random.Range(0, totalWaves));
        if(randNum > _wavePool.Count)
        {
            randNum -= _wavePool.Count;
            selectedWave = _elitePool[randNum];
            _elitePool.Remove(selectedWave);
            remainingElites--;
        }
        else
        {
            selectedWave = _wavePool[randNum];
            _wavePool.Remove(selectedWave);
            remainingWaves--;
        }
        return;
    }

    void OnLevelComplete() //Runs when currentState = states.win
    {
        currentState = states.paused;
    }
}
