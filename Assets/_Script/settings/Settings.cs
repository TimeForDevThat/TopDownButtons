using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[AddComponentMenu("Settings/Settings")]
public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle toggleEffect;
    public Toggle toggleReload;
    public Volume PostProcessVolume;
    private static bool isFullScreen, off_onEffect, autoReload;

    Resolution[] resolutions;
    private void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> optins = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            optins.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(optins);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void off_onEffectToggle() {
        off_onEffect = !off_onEffect;
        PostProcessVolume.enabled = !off_onEffect;
    }

    public void AutoReloadToggle() {
        autoReload = !autoReload;
        toggleReload.isOn = autoReload;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings() {
        PlayerPrefs.SetInt("ResolutionPrefence", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPrefence", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetInt("autoReload", System.Convert.ToInt32(autoReload));
        PlayerPrefs.SetInt("off_onEffect", System.Convert.ToInt32(off_onEffect));
    }

    public void LoadSettings(int currentResolutionIndex) {
        if (PlayerPrefs.HasKey("ResolutionPrefence"))
            resolutionDropdown.value = currentResolutionIndex;
           
        if (PlayerPrefs.HasKey("FullscreenPrefence"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPrefence"));
        else
            Screen.fullScreen = true;

        if(PlayerPrefs.HasKey("autoReload"))
            toggleReload.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("autoReload"));
        else 
            autoReload = false;

        toggleReload.isOn = autoReload;

        if (PlayerPrefs.HasKey("off_onEffect"))
            toggleEffect.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("off_onEffect"));
        else
            off_onEffect = false;

        toggleEffect.isOn = off_onEffect;
    }
}