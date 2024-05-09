using UnityEngine;

public class Use_CurCartridges : MonoBehaviour
{
    public GameObject Canvas;
    public ParticleSystem ParticleSystem;

    private Weapon _weapon;

    [Header("IntAmmoMagazin")]
    public int ammoMagazin;

    private void OnTriggerStay2D(Collider2D other)
    {
        var ammo = other.GetComponent<Weapon>();
        if (other.gameObject.tag == "Player")
        {
            Canvas.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                ammo.CurCartridges += ammoMagazin;
                ParticleSystem.Play();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) => Canvas.SetActive(false);
}