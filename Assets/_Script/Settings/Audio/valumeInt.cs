using UnityEngine;
using UnityEngine.Audio;

public class valumeInt : MonoBehaviour
{
    public string valumeParametr = "MisterValume";
    public AudioMixer mixer;
    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(valumeParametr, valumeParametr == "AffactVal" ? 0f : -80f);
        mixer.SetFloat(valumeParametr, volumeValue);
    }
}
