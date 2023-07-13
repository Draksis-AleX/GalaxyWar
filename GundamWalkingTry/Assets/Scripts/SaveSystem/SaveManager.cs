using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] ScoreManager _ScoreManager;
    [SerializeField] CoinManager _CoinManager;

    private static SaveManager _instance;
    public static SaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SaveManager>();
                if (_instance == null) Debug.LogError("No saveManager in scene");
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
            data = new GameData();
            if (data.loadData("game") != null)
            {
                data = JsonUtility.FromJson<GameData>(data.loadData("game"));
            }

            data.scene = "debug";
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }

    }

    GameData data;

    private void Start()
    {

    }


    public int whatLoad() {
        if(data.scene == "Magazzino") return 0;
        return 1;
    }


    public void save() {

        Debug.Log("Salvo solo le informazioni score e coin al momento ");

        _ScoreManager.save();
        _CoinManager.saveCoins();

        data.saveData("game");
    }



}
