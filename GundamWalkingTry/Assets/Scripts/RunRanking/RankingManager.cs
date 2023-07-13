using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{

    //======================================= SINGLETON ==========================================

    private static RankingManager _instance;

    public static RankingManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<RankingManager>();
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

    //============================================================================================

    struct RunEntry
    {
        public int id;
        public string date;
        public string time;
        public int waves;
        public string time_played;
        public int score;
    }

    int maxEntries;
    [SerializeField] RunEntry[] rank;
    int current_id = 0;

    private void Start()
    {
        rank = new RunEntry[maxEntries];
    }

    public void saveRun(string date, string time, int waves, int score, float time_played)
    {
        RunEntry newEntry = new RunEntry();
        newEntry.id = current_id++;
        newEntry.date = date;
        newEntry.time = time;
        newEntry.waves = waves;
        newEntry.score = score;

        Debug.Log("New Run Entry: [ #" + newEntry.id + " | " + newEntry.date + " | " + newEntry.time + " | " + newEntry.waves + " | " + newEntry.score + " | " + FormatTime(time_played) + " ] ");


    }

    string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
