using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float valueHealth = 100;
    public Canvas canvas;
    public Slider healthSlider;

    public GameObject point;

    [SerializeField]
    UnityEvent UnityEvent;

    private void Start() { 
        healthSlider.maxValue = valueHealth;
        canvas.gameObject.SetActive(false);
    }

    public bool isAlive() { 
        return valueHealth > 0;
    }

    public void DealDamage(int damage) {

        valueHealth -= damage;
        healthSlider.value = valueHealth;

        UnityEvent.Invoke();

        if (canvas.isActiveAndEnabled == false)
            canvas.gameObject.SetActive(true);

        if (valueHealth <= 0)
            Die();
    }

    private void Die() {
        Instantiate(point, transform.position, transform.rotation);
        Destroy(gameObject);
        GetComponent<EnemyAi2>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
