using UnityEngine;

public class EffectInfoWindows : MonoBehaviour
{
    public float InfoTimer = 2f;

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
            this.gameObject.SetActive(false);
        }
    }
}
