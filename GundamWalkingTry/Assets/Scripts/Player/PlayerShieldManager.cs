using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldManager : MonoBehaviour
{

    [SerializeField] int maxShield = 50;
    [SerializeField] int currentShield;
    [SerializeField] float shieldCooldownTime = 5f;
    [SerializeField] float regenerationTime = 1f;
    [SerializeField] GameObject shieldBar;
    Coroutine latestShieldCooldown;
    bool isRegenerating = false;

    private void Start()
    {
        currentShield = maxShield;
        shieldBar.GetComponent<ShieldBar>().setMaxShield(maxShield);
        shieldBar.GetComponent<ShieldBar>().setShield(maxShield);
    }

    public void reset()
    {
        currentShield = maxShield;
        shieldBar.GetComponent<ShieldBar>().setShield(maxShield);
    }

    public void addMaxShield(int amount)
    {
        maxShield += amount;
        shieldBar.GetComponent<ShieldBar>().setMaxShield(maxShield);
        if (latestShieldCooldown != null) StopCoroutine(latestShieldCooldown);
        latestShieldCooldown = StartCoroutine(shieldCooldown());
    }

    public void takeDamage(int damage)
    {
        if (currentShield > 0)
        {
            currentShield -= damage;
            if (currentShield <= 0)
            {
                if (currentShield < 0)
                {
                    this.GetComponent<PlayerHealthManager>().takeDamage(Mathf.Abs(currentShield));
                    currentShield = 0;
                }
            }
        }
        else
        {
            this.GetComponent<PlayerHealthManager>().takeDamage(damage);
        }
        shieldBar.GetComponent<ShieldBar>().setShield(currentShield);
        if (latestShieldCooldown != null) StopCoroutine(latestShieldCooldown);
        latestShieldCooldown = StartCoroutine(shieldCooldown());
    }

    //============================== SKILLS PARAMETERS ======================================

    public void reduceRegenerationTime(float percentage)
    {
        regenerationTime = regenerationTime - (regenerationTime * percentage);
    }

    public void reduceCooldownTime(float percentage)
    {
        shieldCooldownTime = shieldCooldownTime - (shieldCooldownTime * percentage);
    }

    //============================ REGEN COROUTINES ===========================================

    public IEnumerator shieldCooldown()
    {
        isRegenerating = false;
        Debug.Log("Started Shield Cooldown");
        yield return new WaitForSeconds(shieldCooldownTime);
        Debug.Log("Ended Shield Cooldown");
        isRegenerating = true;
        StartCoroutine(regenerateShield());
    }

    public IEnumerator regenerateShield()
    {
        if (isRegenerating)
        {
            currentShield += 5;
            shieldBar.GetComponent<ShieldBar>().setShield(currentShield);
            if (currentShield > maxShield) currentShield = maxShield;
            yield return new WaitForSeconds(regenerationTime);
            if (currentShield < maxShield) StartCoroutine(regenerateShield());
        }
        else yield return null;
    }
}
