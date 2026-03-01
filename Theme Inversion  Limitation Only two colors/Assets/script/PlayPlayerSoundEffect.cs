using UnityEngine;

public class PlayPlayerSoundEffect : MonoBehaviour
{
    AudioSource src;
    public AudioClip hurt;
    public AudioClip die;
    public AudioClip clip;

    private void Start()
    {
        src = GetComponent<AudioSource>();
    }
    public void hurtAudio()
    {
        src.PlayOneShot(hurt);
    }
    public void dieAudio()
    {
        src.PlayOneShot(die);
    }
    public void breakAudio()
    {
        src.PlayOneShot(clip);
    }
}
