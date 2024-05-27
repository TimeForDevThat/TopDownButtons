using UnityEngine.UI;
using UnityEngine;

[AddComponentMenu("ScriptGun/Weapon")]
public class Weapon : Sounds
{
    public GameObject bullet;
    public float offset;

    public bool isActive = true;

    public GameObject Player;

    public GameObject Self;

    public float rotateZ;
    [Header("ShotSpeed/ReloadSpeed")]
    public float ShootSpeed;
    public float ReloadSpeed;

    [Header("Ammo")]
    public int Cartridges; //��� ��������
    public int CurCartridges; // ������

    [Header("Text")] 
    public Text maxCartridgesText;

    [Header("Effect")]
    public ParticleSystem shotEffect;
    public Transform bulletSpawn; // point ��� �������

    [Header("Timer")]
    public float ReloadTimer = 0f; // не трогать не менять!!!!
    public float ShootTimer = 0.0f; // не трогать не менять

    void Update()
    {
        SpectorMouse();
        CheckAmmoUiUpdate();
        TouchButtonFireUpdate();
        TouchButtonReloadUpdate();
        AutoReload();
        TimeUpdate();
    }

    void SpectorMouse() 
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
    }

    void CheckAmmoUiUpdate()
    {
        maxCartridgesText.text = string.Format("{0:0}", Cartridges + "/" + CurCartridges);

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
        if (Input.GetKey(KeyCode.R) && Cartridges == 0 & CurCartridges > 0 & ReloadTimer <= 0 & isActive == true)
        {
            ReloadCartridges();
        }
    }

    void AutoReload()
    {
        if (Cartridges == 0 & CurCartridges > 0 & ReloadTimer <= 0 & isActive == true)
        {
            ReloadCartridges();
        }
    }

    void TimeUpdate() {
        if (ShootTimer > 0)
            ShootTimer -= Time.deltaTime;

        if (ReloadTimer > 0)
            ReloadTimer -= Time.deltaTime;
    }

    void Shoot()
    {
        shotEffect.Play();
        ShootTimer = ShootSpeed;
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

        Cartridges -= 1;

        PlaySounds(0);
    }

    void YesShoot() 
        => isActive = true;



    
}
