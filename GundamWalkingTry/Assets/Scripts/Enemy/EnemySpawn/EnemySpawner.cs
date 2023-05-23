using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
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

    int currentWave = 0;
    float spawnRange = 20;
    int enemyKilled = 0;

    void Start()
    {
        spawnWaves();
    }

    void Update()
    {
        if(enemyKilled >= waves[currentWave].getEnemySpawnList().Length){
            enemyKilled = 0;
            currentWave++;
            spawnWaves();
        }

    }

    void spawnWaves(){

        //creare griglia 

        for(int i = 0; i < waves[currentWave].getEnemySpawnList().Length; i++){
            Instantiate(waves[currentWave].getEnemySpawnList()[i],FindSpawnLoc(), Quaternion.identity);
        }

    }

    Vector3 FindSpawnLoc(){

        Vector3 SpawnPos;
        float xLoc = Random.Range(-spawnRange, spawnRange + transform.position.x);
        float zLoc = Random.Range(-spawnRange, spawnRange + transform.position.z);
        float yLoc = transform.position.y;

        SpawnPos = new Vector3(xLoc,yLoc,zLoc);

        if(Physics.Raycast(SpawnPos, Vector3.down,5)) {
            return SpawnPos;
        }
        else{
            return FindSpawnLoc();
        }

    }
}
