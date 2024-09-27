using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomButton : MonoBehaviour
{
    public GameObject Player;
    public GameObject Weapon, SecondWeapon;
    public Component[] buttonEffects;

    public float InfoTimer = 2f;
    private Button Self;

    public TMP_Text text;
    public Image Image, Icon;

    public BaseBaff baseBaff;

    [SerializeField] private int _randomEffect;

    void Start() { RandomizeButtons(); Init(); }

    void Init() => Self = GetComponent<Button>();

    void RandomizeButtons() => _randomEffect = Random.Range(0, 7);

    void Buffs()
    {
        switch (_randomEffect) {
            case 0:
                Image.gameObject.SetActive(true);
                text.text = baseBaff.Baffs[4].InfoName;
                Image.color = baseBaff.Baffs[4].color;
                Icon.sprite = baseBaff.Baffs[4].IconImage;
                break;
            case 1:
                Player.GetComponent<PlayerController>()._movementSpeed *= 2;

                Image.gameObject.SetActive(true);
                text.text = baseBaff.Baffs[0].InfoName;
                Image.color = baseBaff.Baffs[0].color;
                Icon.sprite = baseBaff.Baffs[0].IconImage;
                break;
            case 2:
                Weapon.GetComponent<Weapon>().ShootSpeed = 0;
                SecondWeapon.GetComponent<Weapon>().ShootSpeed = 0;

                Image.gameObject.SetActive(true);
                text.text = baseBaff.Baffs[1].InfoName;
                Image.color = baseBaff.Baffs[1].color;
                Icon.sprite = baseBaff.Baffs[1].IconImage;
                break;
            case 4:
                Weapon.GetComponent<Weapon>().CurCartridges += 25;
                SecondWeapon.GetComponent<Weapon>().CurCartridges += 25;

                Image.gameObject.SetActive(true);
                text.text = baseBaff.Baffs[2].InfoName;
                Image.color = baseBaff.Baffs[2].color;
                Icon.sprite = baseBaff.Baffs[2].IconImage;
                break;
            case 6:
                SecondWeapon.SetActive(true);

                Image.gameObject.SetActive(true);
                text.text = baseBaff.Baffs[3].InfoName;
                Image.color = baseBaff.Baffs[3].color;
                Icon.sprite = baseBaff.Baffs[3].IconImage;
                break;
            case 7:
                Weapon.GetComponent<Weapon>().ReloadSpeed = 0;
                SecondWeapon.GetComponent<Weapon>().ReloadSpeed = 0;

                Image.gameObject.SetActive(true);
                text.text = baseBaff.Baffs[5].InfoName;
                Image.color = baseBaff.Baffs[5].color;
                Icon.sprite = baseBaff.Baffs[5].IconImage;
                break;
        }
    }

    void Debuffs()
    {
        switch (_randomEffect) {
            case 5:
                Player.GetComponent<PlayerController>()._movementSpeed /= 2;

                Image.gameObject.SetActive(true);
                text.text = baseBaff.Baffs[6].InfoName;
                Image.color = baseBaff.Baffs[6].color;
                Icon.sprite = baseBaff.Baffs[6].IconImage;
                break;
            case 3:
                Weapon.GetComponent<Weapon>().CurCartridges = 0;

                Image.gameObject.SetActive(true);
                text.text = baseBaff.Baffs[7].InfoName;
                Image.color = baseBaff.Baffs[7].color;
                Icon.sprite = baseBaff.Baffs[7].IconImage;
                break;
        }
    }

    public void EffectSelect() { Buffs(); Debuffs(); }

    public void SetInactive() => Self.interactable = false;
}