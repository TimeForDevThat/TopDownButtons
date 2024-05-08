using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("ScriptGun/Terget")]
public class Target : MonoBehaviour
{
    public int _health = 50;

    public UnityEvent _hit;

    public void TakeDamage(int damage) {
        _hit.Invoke();
        _health -= damage;
        if (_health <= 0) {
            Die();
        }
    }

    void Die() 
        => Destroy(gameObject);
}