using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Destroy Coin");
            Destroy(transform.parent.gameObject);
        }
    }
}
