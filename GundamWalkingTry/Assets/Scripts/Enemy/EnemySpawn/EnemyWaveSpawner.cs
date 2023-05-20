using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{

    [System.Serializable]

    public class Wave{
        [SerializeField][NonReorderable] GameObject[] enemySpawner;

        public GameObject[] getEnemySpawnList(){
            return enemySpawner;
        }
    }

    //main class 

    [SerializeField][NonReorderable] Wave[] waves;
    [SerializeField] GameObject _EnemySpawnPoints;
    private static EnemyWaveSpawner _instance;


    int currentWave = 0;
    int enemyKilled = 0;

    void Start()
    {   
        spawnWaves();
    }

    void spawnWaves(){


        int SpawnCounter = _EnemySpawnPoints.transform.childCount;
        Debug.Log("PropsSP Counter: " + SpawnCounter);

        bool[] spawnStatus = new bool[SpawnCounter];
        int propID = 0;

        for (int i = 0; i < waves[currentWave].getEnemySpawnList().Length; i++){

            do
            {
                propID = Random.Range(0, SpawnCounter);
            } while (spawnStatus[propID] == true);

            spawnStatus[propID] = true;

            Instantiate(waves[currentWave].getEnemySpawnList()[i], _EnemySpawnPoints.transform.GetChild(propID).transform.position, Quaternion.identity);
        }

    }


    public static EnemyWaveSpawner Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EnemyWaveSpawner>();
                if (_instance == null) Debug.LogError("No EnemyManager in scene");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void EnemyDeath() {

        enemyKilled++;

        if (enemyKilled >= waves[currentWave].getEnemySpawnList().Length)
        {
            enemyKilled = 0;
            currentWave++;
            spawnWaves();
        }
    }
}
