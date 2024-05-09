using UnityEngine;

public class Use_CurCartridges : MonoBehaviour
{
    public GameObject Canvas;
    public ParticleSystem ParticleSystem;

    private Weapon _weapon;

    [SerializeField]private int MinAmmo, MaxAmmo;

    private void OnTriggerStay2D(Collider2D other)
    {
        var ammo = other.GetComponent<Weapon>();
        if (other.gameObject.tag == "Player")
        {
            Canvas.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                ammo.CurCartridges += Random.Range(MinAmmo, MaxAmmo);
                ParticleSystem.Play();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) => Canvas.SetActive(false);
}