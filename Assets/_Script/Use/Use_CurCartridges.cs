using UnityEngine;

public class Use_CurCartridges : MonoBehaviour
{
    public GameObject Canvas;

    [Header("IntAmmoMagazin")]
    public int ammoMagazin;

    private void OnTriggerStay(Collider other)
    {
        var ammo = other.GetComponent<Weapon>();
        if (other.gameObject.tag == "Player")
        {
            Canvas.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                ammo.CurCartridges += ammoMagazin;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other) => Canvas.SetActive(false);
}