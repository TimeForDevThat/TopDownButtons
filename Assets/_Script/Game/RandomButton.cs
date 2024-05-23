using System.Collections.Generic;
using UnityEngine;

public class RandomButton : MonoBehaviour
{
    public Component[] buttonEffects;
    public GameObject Player;
    [SerializeField] private int _randomEffect;
    public GameObject Weapon;
    void Start()
    {
        RandomizeButtons();
    }

    void RandomizeButtons()
    {
        _randomEffect = Random.Range(0, 20);
    }

    void Buffs()
    {
        if (_randomEffect == 1)
        {
            Player.GetComponent<PlayerController>()._movementSpeed *= 2;
        }

        if(_randomEffect == 2)
        {
            Weapon.GetComponent<Weapon>().ShootSpeed = 0;
        }

        if (_randomEffect == 3)
        {
            //Player.GetComponent<PlayerHelth>()._value 
        }

    }

    void Debuffs()
    {
        if(_randomEffect == 11)
        {
            Player.GetComponent<PlayerController>()._movementSpeed /= 2;
        }

        if (_randomEffect == 12)
        {
            Weapon.GetComponent<Weapon>().CurCartridges = 0;
        }
    }
     public void EffectSelect()
    {
        Buffs();
        Debuffs();
    }
}
