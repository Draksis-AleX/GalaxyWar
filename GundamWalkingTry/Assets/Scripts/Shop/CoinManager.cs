using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    //====================================  SINGLETON  ==========================================

    private static CoinManager _instance;

    public static CoinManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CoinManager>();
                if (_instance == null) Debug.LogError("No PlayerInput in scene");
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

    public int getCoins() { return my_coins; }
    public void setCoins(int coins) { my_coins = coins; }
    public void addCoins(int coins) { my_coins += coins; }
}
