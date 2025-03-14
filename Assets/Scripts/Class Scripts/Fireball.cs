using UnityEngine;
using System;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;             // How fast the fireball moves
    public float damage = 1;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();

        if (player != null)
        {
            Debug.Log("Player Hit");
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }

}