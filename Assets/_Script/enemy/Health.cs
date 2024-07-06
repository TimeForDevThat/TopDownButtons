using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float valueHealth = 100;
    public Canvas canvas;
    public Slider healthSlider;

    [SerializeField]
    UnityEvent UnityEvent;

    private PlayerProgress PlayerProgress;

    private void Start() { 
        healthSlider.maxValue = valueHealth;
        canvas.gameObject.SetActive(false);
        PlayerProgress = FindObjectOfType<PlayerProgress>();
    }

    public bool isAlive() { 
        return valueHealth > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bull") {
            UnityEvent.Invoke();
            canvas.gameObject.SetActive(true);
        }
    }

    public void DealDamage(int damage) {

        valueHealth -= damage;
        healthSlider.value = valueHealth;
        if (valueHealth <= 0)
        {
            PlayerProgress.AddExperience(damage);
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
