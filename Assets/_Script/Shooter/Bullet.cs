using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 155;
    public float distant = 5;
    public int damage = 10;

    void Update()
    {
        RaycastHit2D other = Physics2D.Raycast(transform.position, transform.up, distant);
        if (other.collider != null) {
            if (other.collider.CompareTag("Enemy"))
            {
                other.collider.GetComponent<Target>().TakeDamage(damage);
                DestroyBull();
            }
        }

        transform.Translate(Vector2.up * force * Time.deltaTime);

        Invoke("DestroyBull", 4f);
    }

    void DestroyBull() {
        Destroy(gameObject);
    }
}
