using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject pausa;
    public GameObject console;

    [Space(5)]
    public GameObject weapon;
    public GameObject weapontwo;

    private void Start()
    {
        if(pausa != null)
            pausa.SetActive(false);
        else return;

        if (console != null)
            console.SetActive(false);
        else return;

    }

    private void Update()
    {
        Pausa();
        Console();
    }

    private void Pausa()
    {
        if (pausa != null)
            if (Input.GetKeyDown(KeyCode.Escape))
                pausa.SetActive(true);
        else return;

        if (pausa != null)
            if (pausa.activeSelf == true)
                StopGame();
            else
                Resume();
        else return;
    }

    private void Console()
    {
        if (console != null)
            if (Input.GetKeyDown(KeyCode.BackQuote))
                console.SetActive(!console.activeSelf);
        else return;
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
