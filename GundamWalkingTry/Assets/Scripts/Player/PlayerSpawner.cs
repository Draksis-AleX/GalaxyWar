using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;

    void Awake()
    {

        PlayerManager.Instance.transform.position = spawnPoint.position;
        PlayerManager.Instance.transform.rotation = spawnPoint.rotation;
        Debug.Log("Player position: " + PlayerManager.Instance.transform.position);
     
    }

    public void Respawn()
    {
        PlayerManager.Instance.transform.position = spawnPoint.position;
        PlayerManager.Instance.transform.rotation = spawnPoint.rotation;
        Debug.Log("Player position: " + PlayerManager.Instance.transform.position);
    }

}
