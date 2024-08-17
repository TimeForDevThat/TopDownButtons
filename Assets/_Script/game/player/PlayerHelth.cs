using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHelth : MonoBehaviour
{
    public int _value = 100;

    [Space(5)]
    [Header("UI")]
    public Slider SliderHelth;
    public GameObject EnemySpawn;
    public GameObject IteamSpawn;
    public GameObject Weapon;
    public GameObject Weapon2;

    [Space(5)]
    public TextMeshProUGUI textMeshPro;
    public string textMenu;
    public GameObject GameOver;
    private GameObject[] _gameObjects;

    private void Start()
    {
        GameOver.SetActive(false);
    }

    private void Update()
        => SliderHelth.value = _value;

    public void DealDamage(int damage)
    {
        SliderHelth.value -= damage;
        _value -= damage;
        if (_value <= 0)
            Die();
    }

    public void AddHealth(int amout)
    {
        _value += amout;
        SliderHelth.value += amout;
    }

    void Die()
    {
        textMeshPro.text = textMenu;
        GameOver.SetActive(true);

        _gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < _gameObjects.Length; i++) {
            //Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length + " :have a tag 'enemy'");
            Destroy(_gameObjects[i]);
        }

        GetComponent<PlayerController>().enabled = false;

        Weapon2.SetActive(false);
        Weapon.SetActive(false);
        EnemySpawn.SetActive(false);
        IteamSpawn.SetActive(false);
    }
}
