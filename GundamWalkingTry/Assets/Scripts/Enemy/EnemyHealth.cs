using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int defaultHealtPoints = 100;
    int healthPoints;
    [SerializeField] GameObject coinPrefab;

    private void Start()
    {
        healthPoints = defaultHealtPoints;
        //transform.GetComponentInChildren<HealthBar>().setMaxHealth(healthPoints);
    }

    public void takeDamage(int damageAmount)
    {
        Debug.Log("Enemy health: " + healthPoints + " -> " + (healthPoints - damageAmount));
        healthPoints -= damageAmount;
        //transform.GetComponentInChildren<HealthBar>().setHealth(healthPoints);

        //GetComponent<EnemySimpleMovement>().setTriggered();

        if (healthPoints <= 0)
        {
            dropCoins();
            Destroy(this.gameObject);
            EnemyWaveSpawner.Instance.EnemyDeath();
        }
    }

    private void dropCoins()
    {
        int min_n_coins = defaultHealtPoints / 20;
        int variability = Mathf.CeilToInt(min_n_coins / 2);
        int n_coins = Random.Range(min_n_coins, min_n_coins + variability);

        Debug.Log("Coins Dropped: " + n_coins);

        for (int i = 0; i < n_coins; i++)
        {
            var coin = Instantiate(coinPrefab, transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2)), Quaternion.identity);
            coin.GetComponent<CoinFollow>().setTarget(PlayerManager.Instance.transform.Find("AimScope"));
        }
    }
}

