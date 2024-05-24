using UnityEngine;
using UnityEngine.Audio;

public class valumeInt : MonoBehaviour
{
    public string valumeParametr = "MasterVolume";
    public AudioMixer mixer;
    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(valumeParametr, 0f);
        mixer.SetFloat(valumeParametr, volumeValue);
    }
}
