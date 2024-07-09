using UnityEngine;

public class Bullet : Sounds
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
                other.collider.GetComponent<Health>().DealDamage(damage);
                PlaySounds(0, destroy: true);
                DestroyBull();
            }
            if (other.collider.CompareTag("Shield"))
            {
                other.collider.GetComponent<shield>().DealDamage(damage);
                PlaySounds(1, destroy: true);
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
