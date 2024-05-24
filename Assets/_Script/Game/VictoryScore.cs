using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScore : MonoBehaviour
{
    [SerializeField] private int score;
    void Start()
    {
        PlayerPrefs.SetInt("WinScore", PlayerPrefs.GetInt("WinScore") + 1);
    }

    private void Update()
    {
        score = PlayerPrefs.GetInt("WinScore");
    }
}
