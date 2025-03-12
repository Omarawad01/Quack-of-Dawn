using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    public Coroutine _deathAnim { private set; get; }
    public IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

    }
    public void ReactToHit()
    {

        // Get ref to wandering AI script
        // Pass in False
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }

        FireballShooter shooter = GetComponent<FireballShooter>();
        if (shooter != null) shooter.ChangeFiringState(FireballShooter.FiringState.PAUSED);

        // Dies
        if(_deathAnim == null) _deathAnim = StartCoroutine(Die());
        // Here you can add effects (e.g., play a sound or animation).
        Debug.Log(gameObject.name + " has been hit!");
        // Destroy the enemy.
        //Destroy(gameObject);
    }
}