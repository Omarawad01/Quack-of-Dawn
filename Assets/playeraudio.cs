using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    public AudioSource audioSource; // Reference to AudioSource
    public AudioClip shootSound;
    public AudioClip deathSound;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>(); // Auto-assign if missing
    }

    public void Shoot()
    {
        if (shootSound != null)
            audioSource.PlayOneShot(shootSound);

        // Your shooting logic here
    }

    public void Die()
    {
        if (deathSound != null)
            audioSource.PlayOneShot(deathSound);

        // Death logic here
        Destroy(gameObject, deathSound.length); // Destroy after sound plays
    }
}
