using UnityEngine;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Field
        [SerializeField] private string sceneToLoad = "PlayScene";
        public SceneFader fader;
        #endregion

        private void Start()
        {
            
        }

        public void Play()
        {
            fader.FadeTo(sceneToLoad);
        }

        public void Quit()
        {
            Debug.Log("Game Quit!!");
            //Unity 에디터에서 명령 무시, 빌드버전에서는 구동
            Application.Quit();
        }

    }

}
