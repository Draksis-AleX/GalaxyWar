using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int waveScore = 1000;
    private static ScoreManager _instance;
    ScoreInfo scoreInfo;
    float timer = 0;
    bool measureTime = false;
    
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
        scoreInfo = GameObject.Find("ScorePanel").GetComponent<ScoreInfo>();
        loadScore();
        scoreInfo.updateScore(score);
    }

    private void Update()
    {
        if (measureTime) timer += Time.unscaledDeltaTime;
    }

    public int getScore() { return score; }

    public void moreScore(int bonus) { 
        score += 5 * bonus;
        scoreInfo.updateScore(score);
        saveScore();
    }

    public void lessScore(int malus){ 
        score -= 1*malus;
        scoreInfo.updateScore(score);
        if (score < 0) score = 0;
    }

    public void resetScore() { 
        score = 0;
        scoreInfo.updateScore(score);
        saveScore();
    }

    public void StartTimer()
    {
        measureTime = true;
    }

    public void StopTimer()
    {
        measureTime = false;
        //Debug.Log("Completation Time: " + timer);
        Debug.Log("Score added: " + (int)Mathf.Ceil((GameManager.Instance.wavesNumber * waveScore) / (timer / 100)));
        moreScore((int)Mathf.Ceil((GameManager.Instance.wavesNumber * waveScore) / (timer / 100))) ;
        timer = 0;
    }

    private void loadScore()
    {

        intSave i = new intSave();

        if (i.loadIntData("score") != null)
        {
            i = JsonUtility.FromJson<intSave>(i.loadIntData("score"));
            //Debug.Log("score:" + i);
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
