using UnityEngine;

public class Btn_Fx : MonoBehaviour
{
    public AudioSource _audioSource;

    [Header("Sounds")]
    [Space(5)]
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void HOVERBUTTON() => _audioSource.PlayOneShot(hoverFx);
    public void CLICKBUTTON() => _audioSource.PlayOneShot(clickFx);
}
