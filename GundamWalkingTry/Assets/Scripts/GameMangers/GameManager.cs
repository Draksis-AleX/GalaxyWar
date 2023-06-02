using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(1);
        GameObject.Find("SceneInitier").GetComponent<FirstSceneInit>().Init();
        resetLife();
    }

    void resetLife()
    {
        PlayerManager.Instance.GetComponent<PlayerHealthManager>().reset();
        PlayerManager.Instance.GetComponent<PlayerShieldManager>().reset();
        VolumeManager.Instance.setVignetteIntensity((float)0);
    }

}
