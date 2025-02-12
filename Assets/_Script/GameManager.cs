using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Sounds
{
    private PlayerController _playerController;
    private PlayerHelth _playerHelth;
    public List<Weapon> _weapons = new();
    private ButtonsCountdownandCall _countdownandCall;

    [Space(5)]
    public TextMeshProUGUI textMeshPro;
    public string[] textMenu;
    public Image PanelGameVO;

    [Space(5)]
    private int _time = 10;
    public Text TextStartTime;

    [Space(5)]
    public GameObject[] ManagerPointSpawn;
    private GameObject[] _gameObjects;

    public GameObject EnemySpawn;
    public GameObject IteamSpawn;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerHelth = FindObjectOfType<PlayerHelth>();
        _countdownandCall = FindObjectOfType<ButtonsCountdownandCall>();
    }

    private void Start()
    {
        if(PanelGameVO != null)
            PanelGameVO.gameObject.SetActive(false);

        if(TextStartTime != null)
            StartCoroutine("StartTime");
    }

    private void Update()
    {
        if(_playerHelth != null && _countdownandCall != null)
            GameVO();

        if (_time == 0)
        {
            for (int i = 0; i < ManagerPointSpawn.Length; i++)
                ManagerPointSpawn[i].SetActive(true);
            foreach (var weapon in _weapons)
                weapon.enabled = true;

            TextStartTime.gameObject.SetActive(false);
            _playerController.enabled = true;
            StopCoroutine("StartTime");
        }
        else {
            for (int i = 0; i < ManagerPointSpawn.Length; i++)
                ManagerPointSpawn[i].SetActive(false);
            foreach (var weapon in _weapons)
                weapon.enabled = false;

            _playerController.enabled = false;
        }
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

    private void VictoryOrIverScreen()
    {
        PanelGameVO.gameObject.SetActive(true);

        _gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < _gameObjects.Length; i++)
            Destroy(_gameObjects[i]);

        EnemySpawn.SetActive(false);
        IteamSpawn.SetActive(false);
    }

    IEnumerator StartTime()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(1);
            _time--;
            TextStartTime.text = _time.ToString();
            if (_time < 1) {
                PlaySounds(0, p1: 0.5f, p2: 0.5f);
                PlaySounds(1, p1: 1, p2: 1);
            }
            else
                PlaySounds(0, p1: 1, p2: 1);
        }
    }
}