using UnityEngine.UI;
using UnityEngine;

[AddComponentMenu("ScriptGun/Weapon")]
public class Weapon : MonoBehaviour
{
    public GameObject Gun;

    public float fireRate = 1;
    public int force = 155;

    public bool isActive = true;

    [Header("Damage")]
    public float damage = 10;

    [Header("ShotSpeed/ReloadSpeed")]
    public float ShootSpeed;
    public float ReloadSpeed;

    [Header("Ammo")]
    public int Cartridges; //кол патронов
    public int CurCartridges; // магазе

    [Header("Text")] 
    public Text maxCartridgesText;

    [Header("Effect")]
    public ParticleSystem shotEffect;
    public Transform bulletSpawn;

    [Header("XRAY")]
    public float range = 15;
    public Camera _camera;

    [Header("Timer")]
    public float ReloadTimer = 0.0f; // Время перезарядки(НЕ ТРОГАТЬ|НЕ МЕНЯТЬ)!!!!
    public float ShootTimer = 0.0f; // Время выстрела(НЕ ТРОГАТЬ|НЕ МЕНЯТЬ)

    public AudioManager audioManager;

    private void Start()
        => InitComponentLinks();

    void InitComponentLinks() {
        audioManager.GetComponent<AudioManager>();
    }

    void Update()
    {
        CheckAmmoUiUpdate();
        TouchButtonFireUpdate();
        TouchButtonReloadUpdate();
        TimeUpdate();
    }

    void CheckAmmoUiUpdate()
    {
        maxCartridgesText.text = Cartridges + "/" + CurCartridges;

        if (Cartridges >= 1)
            maxCartridgesText.color = new Color(255, 255, 255);
        else
            maxCartridgesText.color = new Color(255, 0, 0);
    }

    void TouchButtonFireUpdate()
    {
        if (Input.GetButtonDown("Fire1") & Cartridges > 0 & ReloadTimer <= 0 & ShootTimer <= 0 & isActive == true) {
            Shoot();
        }
    }

    void ReloadCartridges()
    {
        ReloadTimer = ReloadSpeed;

        isActive = false;

        Cartridges = CurCartridges;
        CurCartridges -= 5;
        YesShoot();
    }

    void TouchButtonReloadUpdate()
    {
        if (Input.GetKeyUp(KeyCode.R) & Cartridges == 0 & CurCartridges > 0 & ReloadTimer <= 0 & isActive == true )
            ReloadCartridges();
    }

    void TimeUpdate() {

        if (ShootTimer > 0)
            ShootTimer -= Time.deltaTime;

        if (ReloadTimer > 0)
            ReloadTimer -= Time.deltaTime;
    }

    void Shoot()
    {
        
        ShootTimer = ShootSpeed;
        //Instantiate(shotEffect, bulletSpawn.position, bulletSpawn.rotation); тяжелый способ
        shotEffect.Play();

        Cartridges = Cartridges - 1;

        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
                target.TakeDamage(damage);

            if (hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal * force);
        }
    }

    void YesShoot() 
        => isActive = true;
}
