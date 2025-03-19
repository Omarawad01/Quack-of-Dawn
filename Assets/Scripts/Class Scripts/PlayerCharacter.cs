using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour


{
    [SerializeField] private float maxHealth = 10;
    private float currentHealth;

    public Healthbar healthBar;

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

        if (currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}



