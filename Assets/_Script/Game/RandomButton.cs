using System.Collections.Generic;
using UnityEngine;

public class RandomButton : MonoBehaviour
{
    public GameObject[] button;
    void Start()
        => RandomizeButtons();

    void RandomizeButtons()
    {
        List<GameObject> values = new List<GameObject>();
        for (int i = 0; i < button.Length; i++)
        {
            int random = Random.Range(0, values.Count);
            button[random].SetActive(true);
        }
    }
}
