using UnityEngine;

public class Use_CurCartridges : MonoBehaviour
{
    public GameObject �anvas;
    public Transform point;
    public ParticleSystem _particleSystem;

    private Weapon _weapon;

    [SerializeField]private int MinAmmo, MaxAmmo;

    private void Start()
    => InitComponentLinks();

    void InitComponentLinks()
    {
        _weapon = FindObjectOfType<Weapon>();
        �anvas.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            �anvas.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                _weapon.CurCartridges += Random.Range(MinAmmo, MaxAmmo);
                Instantiate(_particleSystem, point.position, point.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) => �anvas.SetActive(false);
}