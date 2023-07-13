using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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



    [System.Serializable]
    struct RunEntry
    {
        public int id;
        public string date;
        public string time;
        public int waves;
        public string time_played;
        public int score;
    }

    string filename = "ranking";

    int maxEntries;
    RankingData rd;
    int index;
    int current_id = 0;

    private void Start()
    {
        rd = new RankingData();
        index = 0;
    }

    public void saveRun(string date, string time, int waves, int score, float time_played)
    {
        RankingData.RunEntry newEntry = new RankingData.RunEntry();
        newEntry.id = current_id++;
        newEntry.date = date;
        newEntry.time = time;
        newEntry.waves = waves;
        newEntry.score = score;
        newEntry.time_played = FormatTime(time_played);

        //Debug.Log("New Run Entry: [ #" + newEntry.id + " | " + newEntry.date + " | " + newEntry.time + " | " + newEntry.waves + " | " + newEntry.score + " | " + FormatTime(time_played) + " ] ");

        rd.addEntry(newEntry);

        /*run_list.Add(newEntry);
        run_list.Sort(SortByScore);

        foreach(RunEntry run in run_list)
        {
            Debug.Log("Run Entry: [ #" + run.id + " | " + run.date + " | " + run.time + " | " + run.waves + " | " + run.score + " | " + run.time_played + " ] ");
        }*/

        //Debug.Log("Run_list: " + run_list);
    }

    string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    static int SortByScore(RunEntry r1, RunEntry r2)
    {
        return r2.score.CompareTo(r1.score);
    }
}
