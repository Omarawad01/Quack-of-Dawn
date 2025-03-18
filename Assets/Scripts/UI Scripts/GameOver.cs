using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // NOTE: At the moment, the fireball has the gameover script and 
    // will oneshot the player if they touch it. 
    // TODO: Decrease the health of characters instead of oneshotting them (DONE)
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    } 

    public void RestartGame()
    {
        SceneManager.LoadScene("Juans Scene");
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
