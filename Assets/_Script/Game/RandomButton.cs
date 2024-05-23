using System.Collections.Generic;
using UnityEngine;

public class RandomButton : MonoBehaviour
{
    public Component[] buttonEffects;
    public GameObject Player;
    [SerializeField] private int _randomEffect;
    public GameObject Weapon;
    public GameObject Buff1Info;
    public GameObject Buff2Info;
    public float InfoTimer = 2f;
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
            Buff2Info.SetActive(true);


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
