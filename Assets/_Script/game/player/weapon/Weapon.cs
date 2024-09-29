using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("ScriptGun/Weapon")]
public class Weapon : Sounds
{
    public float offset, rotateZ;

    public bool isActive = true;
    private bool autoReload;

    [Space(5)]
    public GameObject bullet, Player, Self;

    [Header("ShotSpeed/ReloadSpeed")]
    public float ShootSpeed, ReloadSpeed;

    [Header("Ammo")]
    public int Cartridges, MaxCartridges;
    public int CurCartridges;

    [Header("UI")] 
    public Text maxCartridgesText;
    public Image Bar;
    public Slider ReloadAmmoCartridges;

    [Header("Effect")]
    public ParticleSystem shotEffect;
    public Transform bulletSpawn;

    [Header("Timer")]
    private float ReloadTimer = 0f, ShootTimer = 0.0f;

    private void Start()
        => Bar.gameObject.SetActive(false);

    void Update()
    {
        SpectorMouse();
        CheckAmmoUiUpdate();
        TouchButtonFireUpdate();
        Reload();
        TimeUpdate();


        if (PlayerPrefs.HasKey("autoReload"))
            autoReload = System.Convert.ToBoolean(PlayerPrefs.GetInt("autoReload"));
        else
            autoReload = false;
    }

    void SpectorMouse() 
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
    }

    void CheckAmmoUiUpdate()
    {
        if (this != null)
            maxCartridgesText.gameObject.SetActive(true);

        maxCartridgesText.text = string.Format("{0:0}", Cartridges + "/" + CurCartridges);

        if (Cartridges >= 1)
            maxCartridgesText.color = new Color(255, 255, 255);
        else
            maxCartridgesText.color = new Color(255, 0, 0);
    }

    public void TouchButtonFireUpdate()
    {
        if (Input.GetButtonDown("Fire1") & Cartridges > 0 & ReloadTimer <= 0 & ShootTimer <= 0 & isActive == true) {
            Shoot();
        }
    }

    void ReloadCartridges()
    {
        Bar.gameObject.SetActive(true);
        isActive = false;

        float elapsedTime = 0;

        StartCoroutine(Loop(100));
        IEnumerator Loop(float value)
        {
            while (elapsedTime < ReloadSpeed) {
                ReloadAmmoCartridges.value = Mathf.Lerp(0, value, elapsedTime / ReloadSpeed);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            Bar.gameObject.SetActive(false);

            if (CurCartridges >= MaxCartridges)
            {
                Cartridges = MaxCartridges;
                CurCartridges -= MaxCartridges;
            }
            else
            {
                Cartridges = CurCartridges;
                CurCartridges = 0;
            }

            isActive = true;
        }
    }

    void Reload()
    {
        if (Cartridges == 0 & CurCartridges > 0 & ReloadTimer <= 0 & isActive == true) {
            if (autoReload == true)
            {
                ReloadCartridges();
            }
            else if (Input.GetKey(KeyCode.R)) {
                ReloadCartridges();
            }
        }
    }

    void TimeUpdate() {
        if (ShootTimer > 0)
            ShootTimer -= Time.deltaTime;

        if(ReloadTimer > 0)
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
}