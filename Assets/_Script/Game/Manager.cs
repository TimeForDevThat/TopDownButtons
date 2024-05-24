using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Pausa;
    public GameObject weapon;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pausa.SetActive(true);
            StopGame();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        weapon.GetComponent<Weapon>().enabled = true;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        weapon.GetComponent<Weapon>().enabled = false;
    }
}
