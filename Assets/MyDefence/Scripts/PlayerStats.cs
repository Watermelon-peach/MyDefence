using UnityEngine;

namespace MyDefence
{
    //플레이어의 속성(데이터)들을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Field
        //소지금
        private static int money;

        //초기 소지금
        [SerializeField] private int startMoney = 400;

        //목숨
        private static int lives;

        //초기 목숨
        [SerializeField] private int startLives = 10;

        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }

        //목숨 읽기 전용 속성
        public static int Lives
        {
            get { return lives; }
        }

        //라운드 카운트
        public static int Rounds { get; set; }
        #endregion

        //소지금 초기값 400
        private void Start()
        {
            //초기화
            //초기 소지금 지급 400
            money = startMoney;
            lives = startLives;
            Rounds = 0;
        }

        #region Money
        //벌기, 쓰기, 소지금 확인 함수 만들기
        public static void AddMoney(int amount)
        {
            money += amount;
        }

        public static bool UseMoney(int amount)
        {
            if (money < amount)
            {
                //Debug.Log("돈 없다 이 놈아");
                return false;
            }
            money -= amount;
            return true;
        }

        public static bool HasMoney(int amount)
        {
            return money >= amount;
            /*if (money < amount)
            {
                return false;
            }
            return true;*/
        }
        #endregion

        #region Life
        //목숨 회복
        public static void AddLives(int amount)
        {
            lives += amount;
        }

        //목숨 소모
        public static void UseLives(int amount)
        {
            lives -= amount;

            if (lives <= 0)
            {
                lives = 0;
            }
        }

       
        #endregion
    }

}
