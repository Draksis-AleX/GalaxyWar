using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstSceneInit : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        Debug.Log("SceneInit...");
        pauseMenu.SetActive(true);
        pauseMenu.SetActive(false);
        PlayerManager.Instance.gameObject.SetActive(true);
        PlayerManager.Instance.GetComponent<Shooting>().initBulletArray();
        PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = true;
        PlayerManager.Instance.gameObject.transform.position = spawnPoint.position;
        Debug.Log("SceneInitialized.");
    }

}
