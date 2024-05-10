using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string obj;

    //public int MinCount, MaxCount;

    public int[] randomCount;

    public void objectUpgrade() {
        //int count = PlayerPrefs.GetInt(obj);
        var count = Random.Range(0, randomCount.Length);
        PlayerPrefs.SetInt(obj, count);
    }
}