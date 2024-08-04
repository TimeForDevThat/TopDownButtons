using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string obj;

    public int[] randomCount;

    public void objectUpgrade() {
        var count = Random.Range(0, randomCount.Length);
        PlayerPrefs.SetInt(obj, count);
    }
}