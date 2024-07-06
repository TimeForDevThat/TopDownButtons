using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace volumeController{
    public class volumeController : MonoBehaviour
    {
        public string volumeParametr = "MasterVolume";
        public AudioMixer mixer;

        [Space(5)]
        [Header("UI")]
        public Slider slider;
        public Text textVolume;

        private float _volumeValue;
        private const float _multiplier = 20f;

        private void Awake()
            => slider.onValueChanged.AddListener(HandSliderValueChanget);

        private void HandSliderValueChanget(float value)
        {
            _volumeValue = Mathf.Log10(value) * _multiplier;
            mixer.SetFloat(volumeParametr, _volumeValue);
            textVolume.text = Mathf.Round(f: value * 100) + "%";
        }

        private void Update()
            => slider.onValueChanged.AddListener(HandSliderValueChanget);

        void Start()
        {
            _volumeValue = PlayerPrefs.GetFloat(volumeParametr, Mathf.Log10(slider.value) * _multiplier);
            slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
        }

        private void OnDisable()
            => PlayerPrefs.SetFloat(volumeParametr, _volumeValue);
    }
}