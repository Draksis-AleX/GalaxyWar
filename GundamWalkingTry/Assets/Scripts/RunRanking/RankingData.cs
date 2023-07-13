using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class RankingData
{
    [System.Serializable]
    public struct RunEntry
    {
        public int id;
        public string date;
        public string time;
        public int waves;
        public string time_played;
        public int score;
    }

    string filename = "ranking";
    
    [SerializeField] public List<RunEntry> run_list;
    int runlimit = 3;

    public RankingData()
    {
        string filepath = Application.persistentDataPath + "/" + filename + ".json";
        RankingData rd = null;
        if (File.Exists(filepath))
        {
            string json_string = File.ReadAllText(filepath);
            rd = JsonUtility.FromJson<RankingData>(json_string);
        } 
        if (rd.run_list != null) run_list = rd.run_list;
        else run_list = new List<RunEntry>();
    }

    public void addEntry(RunEntry entry)
    {
        if(run_list.Count >= runlimit)
        {
            if(entry.score.CompareTo(run_list[runlimit].score) > 0)
            {
                run_list.RemoveAt(runlimit);
                run_list.Add(entry);
            }
        }
        else run_list.Add(entry);

        run_list.Sort(SortByScore);
        string run_list_string = JsonUtility.ToJson(this);
        string filepath = Application.persistentDataPath + "/" + filename + ".json";
        Debug.Log(filepath);
        File.WriteAllText(filepath, run_list_string);
    }

    static int SortByScore(RunEntry r1, RunEntry r2)
    {
        return r2.score.CompareTo(r1.score);
    }

    
}
