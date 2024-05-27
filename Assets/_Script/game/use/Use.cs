using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Use : Sounds
{
    [Header("Количество здоровье если стоит type aidkit")]
    public int[] Helth;
    [Header("Количество патрон если стоит type ammo")]
    public int[] ammo;

    [Space(5)]
    [Header("UI")]
    public Canvas canvas;
    [Space(5)]
    [Header("Спавн particle system")]
    public Transform point;
    public ParticleSystem _particleSystem;

    private PlayerHelth _player;
    private Weapon _weapon;

    public Type type;
    public enum Type { AidKit, Ammo };

    private void Start()
        => InitComponentLinks();

    void InitComponentLinks()
    {
        _weapon = FindObjectOfType<Weapon>();
        _player = FindObjectOfType<PlayerHelth>();
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) {
                PlaySounds(0, destroy: true);
                if (type == Type.AidKit)
                    _player.AddHealth(Helth[Random.Range(0, Helth.Length)]);
                if (type == Type.Ammo)
                    _weapon.CurCartridges += ammo[Random.Range(0, ammo.Length)];
                Instantiate(_particleSystem, point.position, point.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
        => canvas.gameObject.SetActive(false);
}
