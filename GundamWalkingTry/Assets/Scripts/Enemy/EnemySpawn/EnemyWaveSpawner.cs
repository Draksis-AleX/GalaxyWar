using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaveSpawner : MonoBehaviour
{
    //================================== SINGLETON ========================================
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

    //================================ WAVE CLASS ======================================
    [System.Serializable]
    public class Wave{
        [SerializeField] [NonReorderable] GameObject[] enemyType;
        [SerializeField] [NonReorderable] GameObject[] enemySpawner;

        public void Start() {
        
            for (int i = 0; i < enemySpawner.Length; i++) {;
                Debug.Log("filippo"+Random.Range(0, enemyType.Length));
                enemySpawner[i] = enemyType[Random.Range(0, enemyType.Length)];

            }
            
        }
        public GameObject[] getEnemySpawnList(){
            return enemySpawner;
        }
    }

    //============================== MAIN CLASS =========================================

    [SerializeField][NonReorderable] Wave[] waves;
    [SerializeField] GameObject _EnemySpawnPoints;
    private static EnemyWaveSpawner _instance;
    [SerializeField] private GameObject effect;
    [SerializeField] float dist;


    int currentWave = 0;
    int enemyKilled = 0;

    void Start()
    {
        SetWaves();
        spawnWaves();
    }

    void spawnWaves(){


        int SpawnCounter = _EnemySpawnPoints.transform.childCount;
        Debug.Log("PropsSP Counter: " + SpawnCounter);

        bool[] spawnStatus = new bool[SpawnCounter];
        int enemyID = 0;

        for (int i = 0; i < waves[currentWave].getEnemySpawnList().Length; i++){

            do
            {
                enemyID = Random.Range(0, SpawnCounter);
            } while (spawnStatus[enemyID] == true || Vector3.Distance(_EnemySpawnPoints.transform.GetChild(enemyID).transform.position, PlayerManager.Instance.transform.position) <= dist);

            spawnStatus[enemyID] = true;

            Vector3 effecLoc = _EnemySpawnPoints.transform.GetChild(enemyID).transform.position;
            effecLoc.y = effecLoc.y+1;
            effecLoc.z = effecLoc.z + -1;

            Instantiate(effect, effecLoc , Quaternion.identity);
            Instantiate(waves[currentWave].getEnemySpawnList()[i], _EnemySpawnPoints.transform.GetChild(enemyID).transform.position, Quaternion.identity);
            Debug.Log("distanza:" + Vector3.Distance(_EnemySpawnPoints.transform.GetChild(enemyID).transform.position, PlayerManager.Instance.transform.position));
            
        }

    }

    void SetWaves() {
        for (int i = 0; i < waves.Length; i++) waves[i].Start();
   
    }

    public void EnemyDeath() {

        enemyKilled++;

        if (enemyKilled >= waves[currentWave].getEnemySpawnList().Length && currentWave < waves.Length - 1)
        {
            enemyKilled = 0;
            currentWave++;
            spawnWaves();
        }
    }
}
