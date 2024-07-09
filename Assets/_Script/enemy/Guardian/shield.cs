using UnityEngine;
using UnityEngine.Events;

public class shield : Sounds
{
    public float valueHealthShield = 50;

    [SerializeField]
    UnityEvent UnityEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bull")
            UnityEvent.Invoke();
    }

    public void DealDamage(int damage)
    {
        valueHealthShield -= damage;
        if (valueHealthShield <= 0)
            Die();
    }

    private void Die()
    {
        PlaySounds(0, destroy: true);
        Destroy(gameObject);
    } 
}
