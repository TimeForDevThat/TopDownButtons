using UnityEngine;

public class ButtonsCountdownandCall : MonoBehaviour
{
    public float _gametime = 330f, _timetotrigger = 30f;

    private Manager manager;

    private void Awake()
        => manager = FindObjectOfType<Manager>();

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
            manager.ButtonsMenu(true);
    }

    public void ButtonClicked()
    {
        manager.ButtonsMenu(false);
        _timetotrigger = 30f;
    }

    void IsTimeUp()
    {
        if (_gametime < 30)
            _timetotrigger = 30f;
    }
}
