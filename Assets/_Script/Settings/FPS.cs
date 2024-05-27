using UnityEngine;
using UnityEngine.UI;
public class Fps : MonoBehaviour
{
    [SerializeField] int FPS_int = 60;
    [SerializeField] private Text fpsText;
    [SerializeField] private float updateInterval = 0.5f; // интервал обновления FPS

    private float accum = 0.0f; // сумма времени между кадрами
    private int frames = 0; // количество кадров в интервале
    private float timeLeft; // оставшееся время до обновления FPS

    private void Start()
        => timeLeft = updateInterval;

    private void Awake()
        => Application.targetFrameRate = FPS_int;

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;
        float fps = accum / frames;

        if (timeLeft <= 0.0f)
        {
            fpsText.text = $"FPS: {fps:0.}";

            timeLeft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }

        if (fps <= 20)
            fpsText.color = new Color(255, 0, 0);
        else
            fpsText.color = new Color(255, 255, 255);
    }
}
