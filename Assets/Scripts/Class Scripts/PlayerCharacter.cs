using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    private float health;
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
    }
}