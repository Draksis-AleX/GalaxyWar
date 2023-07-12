using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    private static ScoreManager _instance;
    //[SerializeField] TextMeshProUGUI scoreGUI;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ScoreManager>();
                if (_instance == null) Debug.LogError("No score Manager");
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


    void Start() {
        loadScore();
    }

    public int getScore() { return score; }

    public void moreScore(int bonus) { 
        score += 5 * bonus;
        saveScore();
    }

    public void lessScore(int malus){ 
        score -= 1*malus;
        if (score < 0) score = 0;
    }

    public void resetScore() { score = 0; }



    private void loadScore()
    {

        intSave i = new intSave();

        if (i.loadIntData("score") != null)
        {
            i = JsonUtility.FromJson<intSave>(i.loadIntData("score"));
            Debug.Log("score:" + i);
            score = i.value;
        }
        else score = 0;



    }

    public void saveScore()
    {
        intSave i = new intSave();
        i.saveIntData(score, "score");
    }

}
