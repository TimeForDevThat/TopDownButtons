using UnityEngine;

public class Use_CurCartridges : MonoBehaviour
{
    public GameObject canvas;
    public Transform point;
    public ParticleSystem _particleSystem;

    private Weapon _weapon;

    [SerializeField]private int MinAmmo, MaxAmmo;

    private void Start()
    => InitComponentLinks();

    void InitComponentLinks()
    {
        _weapon = FindObjectOfType<Weapon>();
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                _weapon.CurCartridges += Random.Range(MinAmmo, MaxAmmo);
                Instantiate(_particleSystem, point.position, point.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) => canvas.SetActive(false);
}