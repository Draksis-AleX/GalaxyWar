using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinManager :  MonoBehaviour
{

    //====================================  SINGLETON  ==========================================

    private static CoinManager _instance;
    [SerializeField] TextMeshProUGUI coinGui;

    public static CoinManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CoinManager>();
                if (_instance == null) Debug.LogError("No Coin Manager");
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


    //===========================================================================================

    [SerializeField] int my_coins = 0;
    [SerializeField] int MaxCoin = 999999999;

    private void loadCoins() {

        intSave i = new intSave();

        if (i.loadIntData("coins") != null)
        {
            i = JsonUtility.FromJson<intSave>(i.loadIntData("coins"));
            //Debug.Log("coin:" + i);
            my_coins = i.value;
        }

        coinGui.text = "" + my_coins;


    }

    public void saveCoins()
    {
        intSave i = new intSave();
        i.saveIntData(my_coins, "coins");
    }

    private void Start()
    {
        loadCoins();
    }

    public int getCoins() { return my_coins; }

    public void setCoins(int coins) { 
        my_coins = coins; 
        coinGui.text = "" + my_coins; 
    }
    public void addCoins(int coins) {
        if (my_coins + coins > MaxCoin) return;
        my_coins += coins;
        coinGui.text = "" + my_coins; 
    }
    public void pay(int coins) { 
        my_coins -= coins; 
        coinGui.text = "" + my_coins;
        saveCoins();
    }

}
