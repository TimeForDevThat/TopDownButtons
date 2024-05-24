using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AidKit : Sounds
{
    public int HelthAmmo = 50;

    public Canvas canvas;
    public Transform point;
    public ParticleSystem _particleSystem;

    public PlayerController player;
    private PlayerHelth _player;

    private void Start()
        => InitComponentLinks();

    void InitComponentLinks()
    {
        _player = FindObjectOfType<PlayerHelth>();
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                _player.AddHealth(HelthAmmo);
                PlaySounds(0, destroy: true);
                Instantiate(_particleSystem, point.position, point.rotation);
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
        => canvas.gameObject.SetActive(false);
}
