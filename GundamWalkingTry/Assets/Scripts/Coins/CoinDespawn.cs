using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDespawn : MonoBehaviour
{
    GameObject trail;

    private void Awake()
    {
        trail = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.addCoins(1);
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnDestroy()
    {
        trail.transform.parent = null;
        trail.GetComponent<TrailRenderer>().autodestruct = true;
        trail = null;
    }
}
