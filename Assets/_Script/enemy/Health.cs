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
        GetComponent<EnemyAi2>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
