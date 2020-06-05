using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public float waveDelay; //Use this to set when wave spawns
        public int count = 3;
        public float enemyDelay = 1.0f; //Delay between enemies spawning
        public GameObject enemy;
        public Transform spawnTransform;
        [Tooltip("For when Spawn Transform is empty")]
        public Vector3 spawnLocation;
    }

    public Wave[] waves;
    private float waveCountdown;
    //private int currentWave;

    private void Start()
    {
        Debug.Log("There are " + waves.Length + " waves");
        foreach (Wave wave in waves)
        {
            wave.name = "Wave " + System.Array.IndexOf(waves, wave);
        }

        foreach(Wave wave in waves)
        {
            StartCoroutine(SpawnWave(wave));
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        float _enemyDelay = _wave.enemyDelay;
        Vector3 _spawnLocation = _wave.spawnTransform != null ? _wave.spawnTransform.position : _wave.spawnLocation;

        yield return new WaitForSeconds(_wave.waveDelay);
        Debug.Log("Spawning Wave: " + _wave.name);
        for(int i = 0; i < _wave.count; i++)
        {
            Instantiate(_wave.enemy, _spawnLocation, Quaternion.Euler(0, 0, 90));
            yield return new WaitForSeconds(_wave.enemyDelay);
        }
        
        yield return null;
    }

    private void OnLevelClear()
    {

    }

    private void OnGUI()
    {
        
    }
}
