using TMPro;
using UnityEngine;

public class ButtonsCountdownandCall : MonoBehaviour
{
    [SerializeField] private float _gametime = 330f, _timetotrigger = 30f;
    public GameObject ButtonsMenu, weapon, weapontwo;

    [Space(5)]
    public TextMeshProUGUI textMeshPro;
    public string textMenu;
    public GameObject VictoryMenu;

    void Update()
    {
        _gametime -= Time.deltaTime;
        _timetotrigger -= Time.deltaTime;
        CheckNTrigger();
        IsTimeUp();
    }

    void CheckNTrigger()
    {
        if (_timetotrigger <= 0)
        {
            ButtonsMenu.SetActive(true);
            ZaWarudo();
        }
    }

    public void ButtonClicked()
    {
        ButtonsMenu.SetActive(false);
        Time.timeScale = 1;
        weapon.GetComponent<Weapon>().enabled = true;
        weapontwo.GetComponent<Weapon>().enabled = true;
        _timetotrigger = 30f;
    }

    void IsTimeUp()
    {
        if (_gametime < 30)
        {
            _timetotrigger = 30f;
            if (_gametime <= 0)
            {
                ZaWarudo();
                VictoryScreenCall();
            }
        }
    }

    void ZaWarudo()
    {
        Time.timeScale = 0;
        weapon.GetComponent<Weapon>().enabled = false;
        weapontwo.GetComponent<Weapon>().enabled = false;
    }

    void VictoryScreenCall()
    {
        textMeshPro.text = textMenu;
        VictoryMenu.SetActive(true);
    }
}
