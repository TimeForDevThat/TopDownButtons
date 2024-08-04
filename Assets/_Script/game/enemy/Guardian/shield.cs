using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class shield : Sounds
{
    public float valueHealthShield = 50;
    public Canvas canvas;
    public Slider healthSlider;

    [SerializeField]
    UnityEvent UnityEvent;

    private void Start()
    {
        healthSlider.maxValue = valueHealthShield;
        canvas.gameObject.SetActive(false);
    }

    public void DealDamage(int damage)
    {
        valueHealthShield -= damage;
        healthSlider.value = valueHealthShield;

        UnityEvent.Invoke();

        if (canvas.isActiveAndEnabled == false)
            canvas.gameObject.SetActive(true);

        if (valueHealthShield <= 0)
            Die();
    }

    private void Die()
    {
        PlaySounds(0, destroy: true);
        Destroy(gameObject);
    } 
}
