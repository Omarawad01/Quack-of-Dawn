using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    // Projectile to shoot
    [SerializeField] GameObject fireballPrefab;

    public float sphereCastRadius = 1f;
    public float detectionRange = 5f;
    public float fireballCooldown = .09f;
    private float _currentCooldown;
    public int damage = 1;

    public enum FiringState
    {
        PAUSED,
        ALLOWED_TO_FIRE,
        COOLDOWN
    };
    private FiringState _firingState;

    private void Start()
    {
        _currentCooldown = 0.5f;
        _firingState = FiringState.ALLOWED_TO_FIRE;
    }
    
    public void ChangeFiringState(FiringState newState)
    {
        _firingState = newState;
    }

    private void Update()
    {
        if (_firingState == FiringState.ALLOWED_TO_FIRE)
        {
            if(!Mathf.Approximately(_currentCooldown, 0f))
            {
                _currentCooldown -= Time.deltaTime;
                _currentCooldown = Mathf.Max(0f, _currentCooldown);
            }
        }

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if(Physics.SphereCast(ray, sphereCastRadius, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (Mathf.Approximately(_currentCooldown, 0f))
                    {
                        GameObject fireball = Instantiate(fireballPrefab);
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;

                        _currentCooldown = fireballCooldown;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            Debug.Log("Player Hit!");
            player.Hurt(damage);
        }
        Destroy(gameObject);
    }

}

