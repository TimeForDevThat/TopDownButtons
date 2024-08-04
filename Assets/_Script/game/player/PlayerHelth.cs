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

    public Weapon Weapon;

    [Space(5)]
    public TextMeshProUGUI textMeshPro;
    public string textMenu;
    public GameObject GameOver;

    private void Start()
        => GameOver.SetActive(false);

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

        GetComponent<PlayerController>().enabled = false;
        Weapon.GetComponent<Weapon>().enabled = false;
        EnemySpawn.GetComponent<SpawnerEnemy>().enabled = false;
    }

}
