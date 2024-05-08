using UnityEngine;
using UnityEngine.UI;

public class Helth : MonoBehaviour
{
    public float _value = 100;

    [Header("UI")]
    public Slider SliderHelth;
    public GameObject GameOver;

    private void Start()
        => InitComponentLinks();

    void InitComponentLinks()
    {
        SliderHelth.maxValue = _value;
        GameOver.SetActive(false);
    }

    public void DealDamage(float damage)
    {
        _value -= damage;
        SliderHelth.value -= damage;
        if (_value <= 0)
            Die();
    }

    void Die()
    {
        GameOver.SetActive(true);
        GetComponent<PlayerControll>().enabled = false;
    }

    public void AddHealth(float amout)
    {
        _value += amout;
        SliderHelth.value += amout;
    }
}
