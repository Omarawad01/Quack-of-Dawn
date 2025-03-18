using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]private float maxHealth = 10;
    private float currentHealth;

    public HealthBar healthBar;
    /**private float health;
    private float shield;


    void Start()
    {
        health = 5;
        shield = 3;
    }

    public void Hurt(float damage)
    {
        if (shield > 0)
        {
            shield -= damage;
            Debug.Log($"Shield: " + shield);
        }
        if (shield == 0)
        {
            health -= damage;
            Debug.Log($"Health: " + health);
        }
        if (health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }*/

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    public void Hurt(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Health: " + currentHealth);

        if(currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}