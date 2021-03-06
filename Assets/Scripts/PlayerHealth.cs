using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public bool canTakeDamage = true;
    public float invincibilityFlashDelay = 0.15f;
    public float invincibilityDuration = 3f;

    public SpriteRenderer spriteRenderer;
    public AdvancedHealth healthBar;
    public GameOver gameOverUI;
    public GameObject victoryUI;

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
        if (canTakeDamage)
        {
            if (currentHealth > 1)
            {
                currentHealth -= 1;
                healthBar.setHealth(currentHealth);
                canTakeDamage = false;
                StartCoroutine(InvincibilityFlash());
                StartCoroutine(HandleInvincibilityDelay());
            }
            else if (currentHealth == 1)
            {
                Death();
            }
        }
    }
    public void Death()
    {
        healthBar.setHealth(0);
        gameOverUI.Show();
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
        if (maxHealth == 6)
        {
            StartCoroutine(LoadVictory());
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while (!canTakeDamage)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityDuration);
        canTakeDamage = true;
    }

    public IEnumerator LoadVictory()
    {
        yield return new WaitForSeconds(0.3f);
        victoryUI.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(0);
    }

}
