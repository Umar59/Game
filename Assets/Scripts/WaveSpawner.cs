using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
        public Transform Boss;

    }
    public Wave[] waves;
    public Transform[] spawn_points;
    private int nextWave = 0;                                           //опрериует массивом           ||                  operates the array

    public float timeBetweenWaves = 5f;
    public float waveCountdown;                                         //время до начала волны        ||                  time to start the wave

    private float SearchCountdown = 1f;                                //Ниже описано                  ||                  described down below

    private SpawnState state = SpawnState.COUNTING;
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
       
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive(waves[nextWave].Boss))                          //стартует новый раунд      тут можно прописать награждение игрока экспишками и тп
            {                                            //starts a new rounf        here u can write down some funcs to reward the player and so on
                WaveCompleted();

            }
            else return;

        }


        if (waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));                                         // запускает корутину, чтобы не спавнить волны каждый фрейм в апдейте
            }                                                                                      // starts coroutine preventin waves from spawning every single frame in update method

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
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        nextWave++;
    }
    bool EnemyIsAlive(Transform Boss)                                                                             // проверяет живы ли противники
    {                                                                                              // каждые SearchCountdown секунд, чтобы не пробевать по всем объектам в сцене каждый фрейм
        SearchCountdown -= Time.deltaTime;
        if (SearchCountdown <= 0f)                                                                  //Checks if enemies are alive
        {                                                                                          //each SearchCountdown seconds to not get overload by searching fo tag in the scene each frame
            SearchCountdown = 1f;                                                                           //возобнавляем счетчик

            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Instantiate(Boss, transform.position, transform.rotation);
                return false;
                               
            }
           
        }
        return true;
    }
    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < wave.count; i++)                                                            //спавнит врагов через определенный промежуток времени wave.rate
        {                                                                                              //spawns enemies each 1/wave.rate seconds
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }


        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform enemy)                                                                //функция спавна
    {                                                                                              //spawn function itself
        Transform sp = spawn_points[UnityEngine.Random.Range(0, spawn_points.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }
}
