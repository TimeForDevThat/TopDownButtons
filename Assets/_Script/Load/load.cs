using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    AsyncOperation asyncOperation;

    public Image image;
    public Text Text;
    public int SceneID;
    void Start()
        => StartCoroutine(LoadScene());

    IEnumerator LoadScene() { 
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(SceneID);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            Text.text = "Загрузка" + string.Format("{0:0}%", progress * 100f);
            yield return 0;
        }
    }
}