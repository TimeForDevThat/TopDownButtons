using UnityEngine;

public class ButtonsCountdownandCall : MonoBehaviour
{
    public float _gametime = 330f, _timetotrigger = 30f;
    public GameObject ButtonsMenu, weapon, weapontwo;

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
            }
        }
    }

    void ZaWarudo()
    {
        Time.timeScale = 0;
        weapon.GetComponent<Weapon>().enabled = false;
        weapontwo.GetComponent<Weapon>().enabled = false;
    }
}
