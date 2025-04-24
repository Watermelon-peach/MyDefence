using UnityEngine;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Field
        [SerializeField] private string sceneToLoad = "LevelSelect";
        public SceneFader fader;
        #endregion


        public void Play()
        {
            fader.FadeTo(sceneToLoad);
        }

        public void Quit()
        {
            //cheating
            //PlayerPrefs.DeleteAll();
            //Debug.Log("Game Quit!!");
            //Unity 에디터에서 명령 무시, 빌드버전에서는 구동
            Application.Quit();
        }


        //레벨 초기화버튼
        public void ResetButton()
        {
            PlayerPrefs.DeleteAll();
        }
    }

}
