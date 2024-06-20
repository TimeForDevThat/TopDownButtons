using UnityEngine;
using UnityEngine.UI;

public class Show_Text : MonoBehaviour
{
    [SerializeField] Text HeartText;

    private void Start()
        => HeartText.gameObject.SetActive(false);

    public void OnMouseOver()
        => HeartText.gameObject.SetActive(true);

    public void OnMouseExit()
        => HeartText.gameObject.SetActive(false);
}
