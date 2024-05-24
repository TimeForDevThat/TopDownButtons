using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int WinScore;
    public GameObject Victory;
    public GameObject WinScoreText;
    void Start()
    {
        WinScore = PlayerPrefs.GetInt("WinScore");
        WinScoreText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Прохождений:" + WinScore);
    }

    void Update()
    {

    }
}
