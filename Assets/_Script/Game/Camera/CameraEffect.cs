using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffect : MonoBehaviour
{
    public PlayerController PlayerController;

    public float speed_postProccesing = 2f;
    private float t, t2;
    private PostProcessVolume _PostProcessVolume;
    private Vignette _vignette;

    private void Start()
    {
        _PostProcessVolume = GetComponent<PostProcessVolume>();
        _PostProcessVolume.profile.TryGetSettings(out _vignette);
    }

    private void Update()
    {
        if (PlayerController.theRoom == true)
        {
            if (_vignette.intensity.value != 1)
            {
                _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, 0.5f, t);
                t += Time.deltaTime / speed_postProccesing;
            }
        }
        else if (PlayerController.theRoom == false) {
            if (_vignette.intensity.value != 0)
            {
                _vignette.intensity.value = Mathf.Lerp(_vignette.intensity.value, 0, t2);
                t2 += Time.deltaTime / speed_postProccesing;
                Invoke("Restart", speed_postProccesing);
            }
        }
    }

    void Restart() {
        t2 = 0f;
        t = 0f;
    }
}
