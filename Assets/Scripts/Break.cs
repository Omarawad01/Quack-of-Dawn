using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [Header("Break Settings")]
    [Tooltip("Prefab to instantiate when the object breaks (should be the broken version)")]
    public GameObject brokenPrefab;  // Prefab representing the broken object
    [Tooltip("Minimum force required to break the object on collision (if not colliding with the Player)")]
    public float breakForceThreshold = 5f;
    [Tooltip("Destroy the intact object after breaking?")]
    public bool destroyAfterBreak = true;

    private bool hasBroken = false;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the Player or if the collision force exceeds the threshold.
        if (collision.gameObject.CompareTag("Player") || collision.relativeVelocity.magnitude >= breakForceThreshold)
        {
            Break();
        }
    }

    void Break()
    {
        if (hasBroken)
            return;
        hasBroken = true;

        // Instantiate the broken version at the same position and rotation.
        if (brokenPrefab != null)
        {
            Instantiate(brokenPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Broken prefab not assigned on " + gameObject.name);
        }

        // Optional: add additional effects here, such as playing a sound or triggering particles.

        if (destroyAfterBreak)
        {
            Destroy(gameObject);
        }
    }
}
