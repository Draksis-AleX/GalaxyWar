using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    
    [SerializeField] int defaultHealth = 200;
    [SerializeField] GameObject healthBar;
    [SerializeField] float PU_effect_multiplier = 1;
    [SerializeField] int damageIgnoreProbability = 0;
    int currentHealth;

    float maxVignetteIntensity = 0.4f;

    private void Start()
    {
        currentHealth = defaultHealth;
        healthBar = HUDManager.Instance.gameObject.transform.Find("Health Bar").gameObject;
        healthBar.GetComponent<HealthBar>().setMaxHealth(defaultHealth);
        healthBar.GetComponent<HealthBar>().setHealth(currentHealth);
    }

    public void takeDamage(int damage)
    {
        if(damageIgnoreProbability != 0)
        {
            int extractedNumber = Random.Range(0, 100);
            if (extractedNumber < damageIgnoreProbability) return;
        }

        currentHealth -= damage;
        healthBar.GetComponent<HealthBar>().setHealth(currentHealth);
        if(currentHealth <= defaultHealth / 2)
        {
            double vignette_intensity = maxVignetteIntensity - ((((float)currentHealth)/((float)(defaultHealth+1)/2f))*maxVignetteIntensity);
            Debug.Log(maxVignetteIntensity + " - (" + currentHealth + " / " + defaultHealth / 2 + ") * 0.4 = " + vignette_intensity);
            VolumeManager.Instance.setVignetteIntensity((float)vignette_intensity);
            if(currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void addMaxHealth(int health)
    {
        defaultHealth += health;
        healthBar.GetComponent<HealthBar>().setMaxHealth(defaultHealth);
    }

    public void heal(int health)
    {
        currentHealth += Mathf.CeilToInt(health * PU_effect_multiplier);
        if (currentHealth > defaultHealth) currentHealth = defaultHealth;
    }

    public void setPUMultiplier(float multiplier){ this.PU_effect_multiplier = multiplier; }
    public void addDIProbability(int prob) { damageIgnoreProbability += prob; }

    private void Die()
    {
        GameManager.Instance.runRestart();
    }

    public void reset()
    {
        currentHealth = defaultHealth;
        healthBar.GetComponent<HealthBar>().setHealth(currentHealth);
    }
}
