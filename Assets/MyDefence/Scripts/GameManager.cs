using UnityEngine;

namespace MyDefence
{
    public class GameManager : MonoBehaviour
    {
        #region Field
        [SerializeField]private bool isCheat = false;

        //게임오버
        //UI
        public GameObject gameOverUI;

        private static bool isGameOver = false;
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
