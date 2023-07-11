using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    //====================================  SINGLETON  ==========================================

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if (_instance == null) Debug.LogError("No GameManager in scene");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    //========================== RESTART RUN ==========================================

    public void runRestart()
    {
        PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = false;
        StartCoroutine(LoadScene(1));
        resetLife();
        Physics.SyncTransforms();
        PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = true;
    }

    void resetLife()
    {
        PlayerManager.Instance.GetComponent<PlayerHealthManager>().reset();
        PlayerManager.Instance.GetComponent<PlayerShieldManager>().reset();
        VolumeManager.Instance.setVignetteIntensity((float)0);
    }

    private IEnumerator LoadScene(int sceneIndex)
    {
        // Start loading the scene
        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        // Wait until the level finish loading
        while (!asyncLoadLevel.isDone)
            yield return null;
    }
}
