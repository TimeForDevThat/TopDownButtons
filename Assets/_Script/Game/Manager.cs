using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Pausa;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            StopGame();
            Pausa.SetActive(true);
        }
    }

    public void Resume()
        => Time.timeScale = 1.0f;

    public void StopGame()
        => Time.timeScale = 0;
}
