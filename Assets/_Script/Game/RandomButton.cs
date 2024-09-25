using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private Button Self;

    public TMP_Text text;
    public Image Image;
    public Image Icon;

    public BaseBaff baseBaff;

    void Start() { RandomizeButtons(); Init(); }

    void Init() => Self = GetComponent<Button>();

    void RandomizeButtons() => _randomEffect = Random.Range(0, 7);

    void Buffs()
    {
        if (_randomEffect == 1)
        {
            Player.GetComponent<PlayerController>()._movementSpeed *= 2;
            Buff1Info.SetActive(true);

            Image.gameObject.SetActive(true);
            text.text = baseBaff.Baffs[0].InfoName;
            Image.color = baseBaff.Baffs[0].color;
            Icon.sprite = baseBaff.Baffs[0].IconImage;
        }

        if (_randomEffect == 2)
        {
            Weapon.GetComponent<Weapon>().ShootSpeed = 0;
            SecondWeapon.GetComponent<Weapon>().ShootSpeed = 0;
            Buff2Info.SetActive(true);

            Image.gameObject.SetActive(true);
            text.text = baseBaff.Baffs[1].InfoName;
            Image.color = baseBaff.Baffs[1].color;
            Icon.sprite = baseBaff.Baffs[1].IconImage;
        }


        if (_randomEffect == 4)
        {
            Weapon.GetComponent<Weapon>().CurCartridges += 25;
            SecondWeapon.GetComponent<Weapon>().CurCartridges += 25;
            Buff4Info.SetActive(true);

            Image.gameObject.SetActive(true);
            text.text = baseBaff.Baffs[2].InfoName;
            Image.color = baseBaff.Baffs[2].color;
            Icon.sprite = baseBaff.Baffs[2].IconImage;
        }

        if (_randomEffect == 6)
        {
            SecondWeapon.SetActive(true);
            Buff5Info.SetActive(true);

            Image.gameObject.SetActive(true);
            text.text = baseBaff.Baffs[3].InfoName;
            Image.color = baseBaff.Baffs[3].color;
            Icon.sprite = baseBaff.Baffs[3].IconImage;
        }

        if (_randomEffect == 0)
        {
            EmptyEffectInfo.SetActive(true);

            Image.gameObject.SetActive(true);
            text.text = baseBaff.Baffs[4].InfoName;
            Image.color = baseBaff.Baffs[4].color;
            Icon.sprite = baseBaff.Baffs[4].IconImage;
        }

        if (_randomEffect == 7)
        {
            Weapon.GetComponent<Weapon>().ReloadSpeed = 0;
            SecondWeapon.GetComponent<Weapon>().ReloadSpeed = 0;
            Buff3Info.SetActive(true);

            Image.gameObject.SetActive(true);
            text.text = baseBaff.Baffs[5].InfoName;
            Image.color = baseBaff.Baffs[5].color;
            Icon.sprite = baseBaff.Baffs[5].IconImage;
        }
    }

    void Debuffs()
    {
        if (_randomEffect == 5)
        {
            Player.GetComponent<PlayerController>()._movementSpeed /= 2;
            Debuff1Info.SetActive(true);

            Image.gameObject.SetActive(true);
            text.text = baseBaff.Baffs[6].InfoName;
            Image.color = baseBaff.Baffs[6].color;
            Icon.sprite = baseBaff.Baffs[6].IconImage;
        }

        if (_randomEffect == 3)
        {
            Weapon.GetComponent<Weapon>().CurCartridges = 0;
            Debuff2Info.SetActive(true);

            Image.gameObject.SetActive(true);
            text.text = baseBaff.Baffs[7].InfoName;
            Image.color = baseBaff.Baffs[7].color;
            Icon.sprite = baseBaff.Baffs[7].IconImage;
        }
    }
    public void EffectSelect() { Buffs(); Debuffs(); }

    public void SetInactive() => Self.interactable = false;
}