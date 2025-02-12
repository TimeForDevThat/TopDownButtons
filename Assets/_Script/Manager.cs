using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject console, pausa, buttonsMenu;

    private void Start()
    {
        if (console != null || pausa != null || buttonsMenu != null) {
            console.SetActive(false);
            pausa.SetActive(false);
            buttonsMenu.SetActive(false);
        }
        else return;
    }

    private void Update() {
        Console();
        Pausa();
        ButtonsMenu();
    }

    private void Pausa()
    {
        if (pausa != null && Input.GetKeyDown(KeyCode.Escape))
            pausa.SetActive(true);

        if (pausa != null && pausa.activeSelf)
            SetPause(true);
        else
            SetPause(false);
    }

    private void Console()
    {
        if (console != null && Input.GetKeyDown(KeyCode.BackQuote))
            console.SetActive(!console.activeSelf);
    }

    private void ButtonsMenu() { 
        if(buttonsMenu != null && buttonsMenu.activeSelf)
            SetPause(true);
        else
            SetPause(false);
    }

    public void ButtonsMenu(bool panel) => buttonsMenu.SetActive(panel);

    public static void SetPause(bool isEnable)
        => Time.timeScale = isEnable ? 0 : 1;
}