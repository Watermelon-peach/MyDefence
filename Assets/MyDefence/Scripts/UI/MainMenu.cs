using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Field
        [SerializeField] private string sceneToLoad = "PlayScene";
        #endregion

        private void Start()
        {
            
        }

        public void Play()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        public void Quit()
        {
            Debug.Log("Game Quit!!");
            //Unity 에디터에서 명령 무시, 빌드버전에서는 구동
            Application.Quit();
        }

    }

}
