using UnityEngine;
using UnityEngine.UI;

public class PlayerHelth : MonoBehaviour
{
    public int _value = 100;

    [Header("UI")]
    public Slider SliderHelth;
    public GameObject GameOver;

    private void Start()
        => InitComponentLinks();

    void InitComponentLinks()
    {
        SliderHelth.maxValue = _value;
        SliderHelth.value = _value;
        GameOver.SetActive(false);
    }

    public void DealDamage(int damage)
    {
        SliderHelth.value -= damage;
        _value -= damage;
        if (_value <= 0)
            Die();
    }

    void Die()
    {
        GameOver.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Weapon>().enabled = false;
    }

    public void AddHealth(int amout)
    {
        _value += amout;
        SliderHelth.value += amout;
    }
}
