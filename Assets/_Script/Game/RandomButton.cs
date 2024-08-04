using UnityEngine;
using UnityEngine.UI;

public class RandomButton : MonoBehaviour
{
    public Component[] buttonEffects;
    public GameObject Player;
    [SerializeField] private int _randomEffect;
    public GameObject Weapon;
    public GameObject SecondWeapon;
    public GameObject Buff1Info;
    public GameObject Buff2Info;
    public GameObject Buff3Info;
    public GameObject Buff4Info;
    public GameObject Buff5Info;
    public GameObject Debuff1Info;
    public GameObject Debuff2Info;
    public GameObject EmptyEffectInfo;
    public float InfoTimer = 2f;
    public Button Self;
    void Start()
    {
        RandomizeButtons();
    }

    void RandomizeButtons()
    {
        _randomEffect = Random.Range(0, 7);
    }

    void Buffs()
    {
        if (_randomEffect == 1)
        {
            Player.GetComponent<PlayerController>()._movementSpeed *= 2;
            Buff1Info.SetActive(true);
        }

        if(_randomEffect == 2)
        {
            Weapon.GetComponent<Weapon>().ShootSpeed = 0;
            SecondWeapon.GetComponent<Weapon>().ShootSpeed = 0;
            Buff2Info.SetActive(true);
        }


        if (_randomEffect == 4)
        {
            Weapon.GetComponent<Weapon>().CurCartridges += 25;
            SecondWeapon.GetComponent<Weapon>().CurCartridges += 25;
            Buff4Info.SetActive(true);
        }

        if(_randomEffect == 6)
        {
            SecondWeapon.SetActive(true);
            Buff5Info.SetActive(true);
        }

        if(_randomEffect == 0)
        {
            EmptyEffectInfo.SetActive(true);
        }

        if(_randomEffect == 7)
        {
            Weapon.GetComponent<Weapon>().ReloadSpeed = 0;
            SecondWeapon.GetComponent<Weapon>().ReloadSpeed = 0;
            Buff3Info.SetActive(true);
        }
    }

    void Debuffs()
    {
        if(_randomEffect == 5)
        {
            Player.GetComponent<PlayerController>()._movementSpeed /= 2;
            Debuff1Info.SetActive(true);
        }

        if (_randomEffect == 3)
        {
            Weapon.GetComponent<Weapon>().CurCartridges = 0;
            Debuff2Info.SetActive(true);
        }
    }
     public void EffectSelect()
    {
        Buffs();
        Debuffs();
    }

    public void SetInactive()
    {
        Self.interactable = false;
    }
}
