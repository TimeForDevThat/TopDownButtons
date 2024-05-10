using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public float valueHealth = 100;

    public ParticleSystem ParticleSystem;

    public bool isAlive() { 
        return valueHealth > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bull")
            ParticleSystem.Play();
    }

    public void DealDamage(int damage) {

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
