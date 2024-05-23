using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public int what;
    private bool _relvalue;
    int BoolToInt(bool _relvalue)
    {
        if (_relvalue)
            return 1;
        else
            return 0;
    }

    public void AutoChange()
    {

    }

    public void AutoReloadSetting()
    {
        PlayerPrefs.SetInt("AutomaticReload", BoolToInt(_relvalue));
        //if (PlayerPrefs.GetInt("AutomaticReload") == 1)
        //{
        //    PlayerPrefs.SetInt("AutomaticReload", 0);
        //}


        //bool intToBool(int val)
        //{
        //    if (val != 0)
         //       return true;
        //    else
         //       return false;
        //}
    }
    private void Update()
    {
        //what = PlayerPrefs.GetInt("AutomaticReload");
    }
}
