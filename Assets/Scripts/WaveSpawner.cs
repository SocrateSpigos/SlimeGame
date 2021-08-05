using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING};
   // var gos : GameObject[];

    
    [System.Serializable]
    public class Wave
    {

        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Transform[] spawnPoints;
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;
   

    void Start()
    {
        //gos = GameObject.FindGameObjectsWithTag("Enemy");

        waveCountdown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points found");
        }
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }

            
        }



        if (waveCountdown <= 0)
        {

            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if( nextWave + 1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("Looping");
        }
        else
        {
            nextWave++;

        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

            if (searchCountdown <= 0f)
        {
            searchCountdown = 1;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 3)
            {
                return false;
            }
        }
        return true;
    }


    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);

        }

        state = SpawnState.WAITING;
        

    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
       
       
        
        Instantiate(_enemy, _sp.position, _sp.rotation);
        Debug.Log("Spawning Wave :" + _enemy.name);

    }

}
