using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerProgress : Sounds
{
    public List<PlayerProgressLevel> levels;

    public Slider Slider;
    public TextMeshProUGUI levelValueTMP;

    private int _levelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }

    private void Update()
    {
        if(_levelValue == 10)
            SceneManager.LoadScene("EndGame");
    }

    public void AddExperience(int value) { 
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue) {
           SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value) {
        _levelValue = value;
    }

    private void DrawUI()
    {
        Slider.value = _experienceCurrentValue/ _experienceTargetValue;
        levelValueTMP.text = "Убить " + _levelValue.ToString();
        PlaySounds(0);
    }
}
