using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AidKit : Sounds
{
    public int HelthAmmo = 50;

    public Canvas canvas;
    public ParticleSystem _particleSystem;

    private void Start()
        => InitComponentLinks();

    void InitComponentLinks()
       => canvas.gameObject.SetActive(false);

    private void OnTriggerStay2D(Collider2D other)
    {
        var playerHealth = other.GetComponent<PlayerHelth>();
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
                if (playerHealth != null)
                {
                    playerHealth.AddHealth(HelthAmmo);
                    PlaySounds(0, destroy: true);
                    Destroy(gameObject);
                }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
        => canvas.gameObject.SetActive(false);
}
