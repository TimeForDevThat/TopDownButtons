using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : Sounds
{
    public List<PlayerProgressLevel> levels;

    public Slider Slider;
    public TextMeshProUGUI progressbar;
    public TextMeshProUGUI levelValueTMP;

    public Transform point;
    public GameObject gameObj;

    private int _levelValue = 1;
    private int _lowValue = 0;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private Manager manager;

    private void Awake()
        => manager = FindObjectOfType<Manager>();

    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
        SelectExposiad();
    }

    public void AddExperience(int value) { 
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue) {
            SetLevel(_levelValue + 1);
            _experienceTargetValue *= 2;
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value) {
        _levelValue = value;
        if (_lowValue <= 5)
            _lowValue = 0;
        else
            _lowValue++;
        PlaySounds(0);
    }

    private void DrawUI()
    {
        Slider.value = _experienceCurrentValue / _experienceTargetValue;
        progressbar.text = "Очки: " + _experienceCurrentValue + "/" + _experienceTargetValue;
        levelValueTMP.text = "Level: " + _levelValue.ToString();
    }

    private void SelectExposiad() {
        if (_lowValue == 1)
            manager.buttonsMenu.SetActive(true);
    }
}
