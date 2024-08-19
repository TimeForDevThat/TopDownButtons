using UnityEngine;
using UnityEngine.UI;

public class PlayerHelth : MonoBehaviour
{
    public float _value = 100;
    private float _threshold = 100;

    [Space(5)]
    [Header("UI")]
    public Slider SliderHelth;
    public GameObject[] Weapon;

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
        if (_value > _threshold) {
            _value += amout;
            SliderHelth.value += amout;
        }
        else
            _value = _threshold;
    }

    void Die()
    {
        GetComponent<PlayerController>().enabled = false;

        for (int i = 0; i < Weapon.Length; i++)
            Weapon[i].SetActive(false);
    }
}
