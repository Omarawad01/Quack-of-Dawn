using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip death;
    public AudioClip checkpint;
    public AudioClip walltouch;
    public AudioClip portalIn;
    public AudioClip portalOut;



    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
