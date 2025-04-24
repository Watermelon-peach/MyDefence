using UnityEngine;

namespace MyDefence
{
    public class GameManager : MonoBehaviour
    {
        #region Field
        [SerializeField] private bool isCheat = false;

        //게임오버
        //UI
        public GameObject gameOverUI;
        private static bool isGameOver = false;

        //레벨클리어
        [SerializeField] private int unlockLevel = 2;
        #endregion

        #region Property
        public static bool IsGameOver
        {
            get { return isGameOver; }
        }
        #endregion

        private void Start()
        {
            //초기화
            isGameOver = false;

        }
        private void Update()
        {
            if (IsGameOver)
                return;

            

            //게임오버 되었는지 체크
            if (PlayerStats.Lives <= 0)
            {
                ShowGameOverUI();
            }

            //Cheating
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
            if (Input.GetKeyDown(KeyCode.O) && isCheat)
            {
                ShowGameOverUI();
            }
        }

        

        //게임오버 UI 보여주기
        void ShowGameOverUI()
        {
            isGameOver = true;
            gameOverUI.SetActive(true);
        }

        //레벨 클리어 처리
        public void LevelClear()
        {
            Debug.Log("LevelClear");
            //데이터 처리 - 보상, 다음 플레이할 레벨 저장
            int nowLevel = PlayerPrefs.GetInt("NowLevel", 1);
            if (unlockLevel > nowLevel)
            {
                PlayerPrefs.SetInt("NowLevel", unlockLevel);
            }
            
            //...

            //UI 보여주기, VFX, SFX 효과
            Debug.Log("레벨 클리어");
        }

        //Cheating
        //M키를 누르면 10만 골드 지급
        void ShowMeTheMoney()
        {
            if (!isCheat)
                return;

            PlayerStats.AddMoney(100000);
        }

        //레벨업 치팅
        void LevelUpCheat()
        {
            //PlayerStats.LevelUp();
        }

        //...
    }

}
