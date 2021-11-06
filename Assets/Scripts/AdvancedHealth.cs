using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedHealth : MonoBehaviour
{
    public Image[] lifeImgs;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void setMaxHealth(int health)
    {
        maxHealth = health;
        currentHealth = health;
        changeHearts();
    }

    public void setHealth(int health)
    {
        currentHealth = health;
        changeHearts();
    }

    private void changeHearts()
    {
        for (int i = 0; i < lifeImgs.Length; i++)
        {
            if (i > maxHealth - 1)
            {
                lifeImgs[i].gameObject.SetActive(false);
            }
            else
            {
                lifeImgs[i].gameObject.SetActive(true);
                if (i > currentHealth - 1)
                {
                    lifeImgs[i].sprite = emptyHeart;
                }
                else
                {
                    lifeImgs[i].sprite = fullHeart;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
