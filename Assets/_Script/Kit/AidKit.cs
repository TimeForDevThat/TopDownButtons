using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AidKit : MonoBehaviour
{
    public int HelthAmmo = 50;

    public AudioSource AudioSource;
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
                    AudioSource.Play();
                    _particleSystem.Play();
                    Invoke("Destroy", AudioSource.clip.length);
                }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
        => canvas.gameObject.SetActive(false);

    private void Destroy()
        => Destroy(gameObject);
}
