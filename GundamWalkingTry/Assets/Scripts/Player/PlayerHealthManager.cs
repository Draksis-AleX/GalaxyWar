using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    
    [SerializeField] int defaultHealth = 200;
    [SerializeField] GameObject healthBar;
    int currentHealth;

    float maxVignetteIntensity = 0.4f;
    float minVignetteIntensity = 0f;

    private void Start()
    {
        currentHealth = defaultHealth;
        healthBar = HUDManager.Instance.gameObject.transform.Find("Health Bar").gameObject;
        healthBar.GetComponent<HealthBar>().setMaxHealth(defaultHealth);
        healthBar.GetComponent<HealthBar>().setHealth(currentHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.GetComponent<HealthBar>().setHealth(currentHealth);
        if(currentHealth <= defaultHealth / 2)
        {
            double vignette_intensity = maxVignetteIntensity - ((((float)currentHealth)/((float)(defaultHealth+1)/2f))*maxVignetteIntensity);
            Debug.Log(maxVignetteIntensity + " - (" + currentHealth + " / " + defaultHealth / 2 + ") * 0.4 = " + vignette_intensity);
            VolumeManager.Instance.setVignetteIntensity((float)vignette_intensity);
        }
    }
}
