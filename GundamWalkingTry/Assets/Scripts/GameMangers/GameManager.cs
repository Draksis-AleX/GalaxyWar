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
    public bool completedArena = false;
    bool first_arena;
    string run_start_date;
    string run_start_time;
    float run_time;
    bool count_time;
    public int wavesCompleted;

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
        first_arena = true;
        wavesCompleted = 0;
        run_time = 0;
        count_time = false;
    }

    private void Update()
    {
        if (count_time) run_time += Time.unscaledDeltaTime;
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

        RankingManager.Instance.saveRun(run_start_date, run_start_time, wavesCompleted, ScoreManager.Instance.getScore(), run_time);

        ScoreManager.Instance.resetScore();
        count_time = false;
        run_time = 0;
        first_arena = true;
        wavesCompleted = 0;
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
        completedArena = false;
        ScoreManager.Instance.StartTimer();
        if (first_arena)
        {
            Debug.Log("Starting New Run");
            run_start_date = System.DateTime.Now.ToString("dd/MM/yyyy");
            run_start_time = System.DateTime.Now.ToString("hh:mm");
            first_arena = false;
            count_time = true;
        }
    }

    public void DefeatedArena()
    {
        arenaDefeated++;
        ScoreManager.Instance.StopTimer(wavesNumber);
        wavesNumber = (int)Mathf.Ceil(wavesNumber * 1.5f);
        completedArena = true;
    }
}
