using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public PlayerControll player;
    private Helth _player;
    private Target _health;
    public float damage = 30;

    void Start() { InitComponentLinks(); }

    void InitComponentLinks() {
        _player = player.GetComponent<Helth>();
        _health = GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<Helth>();
        if (other.gameObject.tag == "Player")
        {
            _player.DealDamage(damage * Time.deltaTime);
        }
    }
}
