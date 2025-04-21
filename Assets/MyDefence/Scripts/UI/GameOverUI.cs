using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class GameOverUI : MonoBehaviour
    {
        #region Field
        public TextMeshProUGUI roundText;
        public SceneFader fader;
        [SerializeField] private string sceneToLoad = "MainMenu";
        #endregion

        //활성화시 한번만 호출하고 값을 초기화한다
        private void OnEnable()
        {
            roundText.text = PlayerStats.Rounds.ToString();
        }
        
        //다시하기 버튼 클릭 시 호출
        public void RetryButton()
        {
            //게임초기화
            //GameManager.isGameOver = false;
            //...

            //해당 씬(자기 자신)을 다시 부른다
            //SceneManager.LoadScene("PlayScene");    //씬 이름으로 로드
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //빌드 인덱스로 로드
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }

        //메뉴 버튼 클릭 시 호출
        public void MenuButton()
        {
            fader.FadeTo(sceneToLoad);
        }
    }

}
