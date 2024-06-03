using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Load{
    public class load : MonoBehaviour
    {
        AsyncOperation asyncOperation;

        public Image image;
        public Text Text;

        private int SceneID;
        void Start()
            => StartCoroutine(LoadScene());

        public void SceneLoadID(int sceneID)
        {
            SceneID = sceneID;
            gameObject.SetActive(true);
        }

        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(1f);
            asyncOperation = SceneManager.LoadSceneAsync(SceneID);
            while (!asyncOperation.isDone)
            {
                float progress = asyncOperation.progress / 0.9f;
                image.fillAmount = progress;
                Text.text = "Загрузка " + string.Format("{0:0}%", progress * 100f);
                yield return 0;
            }
        }
    }
}