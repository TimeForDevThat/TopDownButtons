using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowPanel : MonoBehaviour
{
    Image image;

    [Header("Изменить альфу гаму")]
    [Space(5)]
    public float min_opacity = 0f;
    public float max_opacity = 0.5f;

    [Header("Время выполнение")]
    [Space(5)]
    public float time = 1;

    public bool IsShow = false;

    void Start()
    {
        var image = GetComponent<Image>();

        Color newColor = image.color;
        image.color = newColor;

        DOTween.Sequence()
            .Append(image.DOFade(min_opacity, 0f))
            .SetEase(Ease.InOutQuart)
            .Append(image.DOFade(max_opacity, time));
    }

    private void Update()
    {
        if (IsShow)
            Invoke("IsShowPanel", time);
    }

    private void IsShowPanel() {
        this.gameObject.SetActive(false);
    }
}
