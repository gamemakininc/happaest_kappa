using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //require wave count, wave name, wave time, spawned enemy & location, delay for each enemy, level clear func

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemy;
        public Vector3 spawnLocation;
        public float enemyDelay; //Use this to delay entrance per enemy
    }
    [System.Serializable]
    public class Wave
    {
        public string name;
        public float waveDelay; //Use this to set when wave spawns
        public Enemy[] enemies;
    }

    public GameObject parent;
    public Wave[] waves;
    private float waveCountdown;
    private int currentWave;

    private void Start()
    {
        Debug.Log(waves.Length);
        foreach (Wave wave in waves)
        {
            wave.name = "Wave " + System.Array.IndexOf(waves, wave);
        }

        waveCountdown = waves[0].waveDelay;
        Invoke("SpawnWave", waveCountdown);
    }

    private void SpawnWave()
    {
        Debug.Log("Spawning wave " + currentWave);
        Enemy[] _enemies = waves[currentWave].enemies;

        for(int i = 0; i < _enemies.Length; i++)
        {
            while (_enemies[i].enemyDelay > 0)
            {
                _enemies[i].enemyDelay -= Time.deltaTime;
            }
            //Debug.Log("Spawning Enemy");
            Instantiate(_enemies[i].enemy, _enemies[i].spawnLocation, parent.transform.rotation, parent.transform);
        }

        currentWave++;
        //Debug.Log(currentWave);
        if (currentWave > waves.Length - 1)
        {

        }
        else
        {
            Invoke("SpawnWave", waves[currentWave].waveDelay);
        }
    }

    private void OnLevelClear()
    {

    }
}
