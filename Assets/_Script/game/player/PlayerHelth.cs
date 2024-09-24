using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerHelth : MonoBehaviour
{
    public float _value = 100;
    private float _threshold = 100;

    [Space(5)]
    [Header("UI")]
    public Slider SliderHelth;
    public GameObject[] Weapon;

    public Volume volume;
    private LiftGammaGain LGG;

    private void Start() {
        volume.profile.TryGet(out LGG);

        LGG.lift.value = new Vector3(1f, 1f, 1f);
        LGG.gamma.value = new Vector3(1f, 1f, 1f);
        LGG.gain.value = new Vector3(1f, 1f, 1f);
    }

    private void Update() => SliderHelth.value = _value;

    public void DealDamage(int damage)
    {
        LGG.lift.value = new Vector3(1f, 0.85f, 0.91f);
        LGG.gamma.value = new Vector3(1f, 0.91f, 0.98f);
        LGG.gain.value = new Vector3(0.47f, 1f, 0.78f);

        Invoke("Restart", 2f);
      
        SliderHelth.value -= damage;
        _value -= damage;
        if (_value <= 0)
            Die();
    }

    public void AddHealth(int amout)
    {
        if (_value > _threshold) {
            _value += amout;
            SliderHelth.value += amout;
        }
        else
            _value = _threshold;
    }

    void Restart() {
        LGG.lift.value = new Vector3(1f, 1f, 1f);
        LGG.gamma.value = new Vector3(1f, 1f, 1f);
        LGG.gain.value = new Vector3(1f, 1f, 1f);
    }

    void Die()
    {
        GetComponent<PlayerController>().enabled = false;

        for (int i = 0; i < Weapon.Length; i++)
            Weapon[i].SetActive(false);
    }
}
