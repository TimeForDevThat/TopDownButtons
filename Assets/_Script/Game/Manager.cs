using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject pausa, console;

    [Space(5)]
    public GameObject weapon;
    public GameObject weapontwo;

    private PlayerHelth _playerHelth;
    private ButtonsCountdownandCall _countdownandCall;

    [Space(5)]
    public TextMeshProUGUI textMeshPro;
    public string[] textMenu;
    public Image PanelGameVO;

    [Space(5)]
    private GameObject[] _gameObjects;

    public GameObject EnemySpawn;
    public GameObject IteamSpawn;

    private void Start()
    {
        if(pausa != null)
            pausa.SetActive(false);

        if (console != null)
            console.SetActive(false);

        if(PanelGameVO != null)
            PanelGameVO.gameObject.SetActive(false);

        _playerHelth = FindObjectOfType<PlayerHelth>();
        _countdownandCall = FindObjectOfType<ButtonsCountdownandCall>();
    }

    private void Update()
    {
        Pausa();
        Console();
        if(_playerHelth != null && _countdownandCall != null)
            GameVO();
    }

    private void GameVO()
    {
        if (_playerHelth._value <= 0) {
            VictoryOrIverScreen();
            textMeshPro.text = textMenu[0];
        }

        if (_countdownandCall._gametime < 30)
        {
            if (_countdownandCall._gametime <= 0)
            {
                textMeshPro.text = textMenu[1];
                VictoryOrIverScreen();
            }
        }
    }

    private void Pausa()
    {
        if (pausa != null)
            if (Input.GetKeyDown(KeyCode.Escape))
                pausa.SetActive(true);

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

    private void VictoryOrIverScreen()
    {
        PanelGameVO.gameObject.SetActive(true);

        _gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < _gameObjects.Length; i++)
            Destroy(_gameObjects[i]);

        EnemySpawn.SetActive(false);
        IteamSpawn.SetActive(false);
    }
}
