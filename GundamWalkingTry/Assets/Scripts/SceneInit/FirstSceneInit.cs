using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstSceneInit : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    PauseMenuManager pauseMenu;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Debug.Log("SceneInit...");
        pauseMenu = GameObject.FindObjectOfType<PauseMenuManager>(true);
        pauseMenu.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        PlayerManager.Instance.gameObject.SetActive(true);
        PlayerManager.Instance.GetComponent<Shooting>().initBulletArray();
        PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = true;
        PlayerManager.Instance.gameObject.transform.position = spawnPoint.position;
        PlayerManager.Instance.gameObject.transform.rotation = spawnPoint.rotation;
        Debug.Log("SceneInitialized.");
    }

}
