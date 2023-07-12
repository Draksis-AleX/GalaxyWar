using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] int arenaDefeated = 0;
    public int nextScene = 2;
    public bool tookPowerUp = false;
    public bool inMagazzino = false;

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

        Init();
    }

    private void Init()
    {
        wavesNumber = 1;
        wave_enemies_number = 2;
    }

    //========================== RESTART RUN ==========================================

    public void runRestart()
    {
        PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = false;
        StartCoroutine(LoadScene(1));
        resetLife();
        resetWaves();
        Physics.SyncTransforms();
        PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = true;
    }

    void resetLife()
    {
        PlayerManager.Instance.GetComponent<PlayerHealthManager>().reset();
        PlayerManager.Instance.GetComponent<PlayerShieldManager>().reset();
        VolumeManager.Instance.setVignetteIntensity((float)0);
    }

    void resetWaves()
    {
        wavesNumber = 1;
        wave_enemies_number = 3;
    }

    private IEnumerator LoadScene(int sceneIndex)
    {
        // Start loading the scene
        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        // Wait until the level finish loading
        while (!asyncLoadLevel.isDone)
            yield return null;
    }

    //=================================================================================

    public int wavesNumber;
    public int wave_enemies_number;

    public void EnteredArena() {
        tookPowerUp = false;
    }

    public void DefeatedArena()
    {
        arenaDefeated++;
        wavesNumber = (int)Mathf.Ceil(wavesNumber * 1.5f);
    }
}
