using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstSceneInit : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Debug.Log("SceneInit...");
        //PauseMenuManager.Instance.gameObject.SetActive(true);
        //PauseMenuManager.Instance.gameObject.SetActive(false);
        PlayerManager.Instance.gameObject.SetActive(true);
        PlayerManager.Instance.GetComponent<Shooting>().initBulletArray();
        PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = true;
        PlayerManager.Instance.gameObject.transform.position = spawnPoint.position;
        Debug.Log("SceneInitialized.");
    }

}
