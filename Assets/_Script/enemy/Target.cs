using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("ScriptGun/Terget")]
public class Target : MonoBehaviour
{
    public float _health = 50f;

    public UnityEvent _hit;

    public void TakeDamage(float amount) {
        _hit.Invoke();
        _health -= amount;
        if (_health <= 0) {
            Invoke("Die", 2f);
        }
    }

    void Die() 
        => Destroy(gameObject);
}