using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowPanel : MonoBehaviour
{
    [field:SerializeField]
    Image image;

    [Header("Изменить альфу гаму")]
    [Space(5)]
    public float min_opacity = 0;
    public float max_opacity = 0.5f;

    [Header("Время выполнение")]
    [Space(5)]
    public float time = 1;

    void Start()
    {
        var image = GetComponent<Image>();

        Color newColor = image.color;
        image.color = newColor;

        newColor.a = min_opacity;

        DOTween.Sequence()
            .SetEase(Ease.InOutQuart)
            .Append(image.DOFade(max_opacity, time));
    }
}
