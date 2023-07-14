using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform spawnPointMagazzino;
    private Transform sp;

    void Awake()
    {

        if (GameManager.Instance.gameData.inMagazzino == true) sp = spawnPointMagazzino;
        else sp = spawnPoint;

        PlayerManager.Instance.transform.position = sp.position;
        PlayerManager.Instance.transform.rotation = sp.rotation;
        Debug.Log("Player position: " + PlayerManager.Instance.transform.position);

        if(SceneManager.GetActiveScene().name != "Magazzino")
            GameManager.Instance.gameData.inMagazzino = false;
     
    }

    public void Respawn()
    {
        if (GameManager.Instance.gameData.inMagazzino == true) sp = spawnPointMagazzino;
        else sp = spawnPoint;

        PlayerManager.Instance.transform.position = sp.position;
        PlayerManager.Instance.transform.rotation = sp.rotation;
        Debug.Log("Player position: " + PlayerManager.Instance.transform.position);
        if (SceneManager.GetActiveScene().name != "Magazzino")
            GameManager.Instance.gameData.inMagazzino = false;
    }

}
