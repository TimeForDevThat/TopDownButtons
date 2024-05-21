using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Dialogue : Sounds
{
    public string[] list;
    public float speedText;
    public TMP_Text Text;

    private int index;

    [SerializeField]
    [Space(5)]
    UnityEvent active;

    private void Start() {
        Text.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void Skip() {
        if (Text.text == list[index])
            Next();
        else { 
            StopAllCoroutines();
            Text.text = list[index];
        }
    }

    private void Next() {
        if (index < list.Length - 1)
        {
            index++;
            Text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else { 
            gameObject.SetActive(false);
            active.Invoke();
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in list[index].ToCharArray())
        {
            Text.text += c;
            PlaySounds(0);
            yield return new WaitForSeconds(speedText);
        }
    }
}