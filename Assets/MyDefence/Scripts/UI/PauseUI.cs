using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class PauseUI : MonoBehaviour
    {
        #region Field
        //씬페이더
        public SceneFader fader;
        [SerializeField]
        private string sceneToLoad = "MainMenu";
        //UI 오브젝트
        public GameObject pauseUI;
        #endregion

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);
            Time.timeScale = pauseUI.activeSelf ? 0f : 1f;
        }

        public void RetryButton()
        {
            Time.timeScale = 1f;

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //빌드 인덱스로 로드
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void MenuButton()
        {
            Time.timeScale = 1f;

            fader.FadeTo(sceneToLoad);
        }

    }
}
