using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Pausa;
    public GameObject Console;

    public GameObject weapon;
    public GameObject weapontwo;

    private void Start()
    {
        Pausa.SetActive(false);
        Console.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pausa.SetActive(true);
        if (Input.GetKeyDown(KeyCode.BackQuote))
            Console.SetActive(!Console.activeSelf);

        if (Pausa.activeSelf == true)
            StopGame();
        else
            Resume();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        weapon.GetComponent<Weapon>().enabled = true;
        weapontwo.GetComponent<Weapon>().enabled = true;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        weapon.GetComponent<Weapon>().enabled = false;
        weapontwo.GetComponent<Weapon>().enabled = false;
    }
}
