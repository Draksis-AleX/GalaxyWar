using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    [SerializeField] GameObject fireParticlePrefab;

    [SerializeField] int damage = 50;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(fireParticlePrefab, this.transform.position, this.transform.rotation);
        this.gameObject.SetActive(false);
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
        }
    }

}
