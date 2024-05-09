using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public float valueHealth = 100;

    private PlayerProgress progress;

    public bool isAlive() { 
        return valueHealth > 0;
    }

    private void Start()
    {
        progress = FindObjectOfType<PlayerProgress>();
    }

    public void DealDamage(int damage) {

        valueHealth -= damage;

        if (valueHealth <= 0)
        {
            progress.AddExperience(damage);
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
