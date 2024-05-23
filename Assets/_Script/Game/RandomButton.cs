using System.Collections.Generic;
using UnityEngine;

public class RandomButton : MonoBehaviour
{
    public Component[] buttonEffects;
    public GameObject Player;
    [SerializeField] private int _randomEffect;
    void Start()
    {
        RandomizeButtons();
    }

    void RandomizeButtons()
    {
        _randomEffect = Random.Range(0, 10);
    }

    void Buffs()
    {
        if (_randomEffect == 1)
        {
            Player.GetComponent<PlayerController>()._movementSpeed *= 10;
        }

        if(_randomEffect == 2)
        {

        }

    }

    void Debuffs()
    {
        if(_randomEffect == 11)
        {
            Player.GetComponent<PlayerController>()._movementSpeed /= 10;
        }
    }
     public void EffectSelect()
    {
        Buffs();
        Debuffs();
    }
}
