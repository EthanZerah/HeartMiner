using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public AdvancedHealth healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void TakeDamage()
    {
        if (currentHealth > 1)
        {
            currentHealth -= 1;
            healthBar.setHealth(currentHealth);
        } else if (currentHealth == 1)
        {
            currentHealth -= 1;
            healthBar.setHealth(currentHealth);
            Debug.Log("Perdu");
        }
    }

    public void Heal()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            healthBar.setHealth(currentHealth);
        }
    }

    public void addHeart()
    {
        if(maxHealth < 6)
        {
            maxHealth += 1;
            currentHealth = maxHealth;
            healthBar.setMaxHealth(maxHealth);
        }
    }
}
