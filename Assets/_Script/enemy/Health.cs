using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public float valueHealth = 100;

    public bool isAlive() { 
        return valueHealth > 0;
    }

    public void DealDamage(float damage) {

        valueHealth -= damage;

        if (valueHealth <= 0)
        {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
