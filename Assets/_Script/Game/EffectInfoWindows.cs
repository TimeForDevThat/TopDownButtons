using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectInfoWindows : MonoBehaviour
{
    public GameObject Self;
    public float InfoTimer = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InfoDisappearAll();  
    }

    void InfoDisappearAll()
    {
        InfoTimer -= Time.deltaTime;
        if(InfoTimer <= 0)
        {
            InfoTimer = 2f;
            Self.SetActive(false);
        }
    }
}
