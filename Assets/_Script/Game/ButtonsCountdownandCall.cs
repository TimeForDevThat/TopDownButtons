using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsCountdownandCall : MonoBehaviour
{
    [SerializeField] private float _gametime = 330f;
    [SerializeField] private float _timetotrigger = 30f;
    public GameObject ButtonsMenu;
    public GameObject weapon;
    public GameObject VictoryMenu;
    void Start()
    {
        
    }

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
    }

    void VictoryScreenCall()
    {
        VictoryMenu.SetActive(true);
    }
    public void TimeReturn()
    {
        if (Time.timeScale == 0)
        {
            _gametime = 2f;
            Time.timeScale = 1;
        }
    }
}
