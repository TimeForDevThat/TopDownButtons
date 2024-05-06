using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource _audioSource;

    [Header("Sounds")]
    [Space(5)]
    public AudioClip hoverFx;
    public AudioClip clickFx;

    [Header("Set volume")]
    [Space(5)]
    [Range(0f, 1f)]
    public float volume;

    void Start()
    {
        _audioSource.GetComponent<AudioSource>().volume = volume;
    }

    public void HOVERBUTTON() => _audioSource.PlayOneShot(hoverFx);
    public void CLICKBUTTON() => _audioSource.PlayOneShot(clickFx);
}
