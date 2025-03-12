using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int shield;


    void Start()
    {
        health = 5;
        shield = 3;
    }

    public void Hurt(int damage)
    {
        shield -= damage;
        if (shield > 0)
        {
            shield -= damage;
            Debug.Log($"Shield: " + shield);
            return;
        }
    }
}