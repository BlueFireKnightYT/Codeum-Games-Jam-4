using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioSource src;
    public AudioClip song;

    private void Start()
    {
        src = GetComponent<AudioSource>();

        src.clip = song;
        src.loop = true;
        src.Play();
    }
}
