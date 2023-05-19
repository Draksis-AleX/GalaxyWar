using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     
    [SerializeField] int healthPoints = 100;

    public void takeDamage(int damageAmount)
    {
        Debug.Log("Enemy health: " + healthPoints + " -> " + (healthPoints - damageAmount));
        healthPoints -= damageAmount;

        if (healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
