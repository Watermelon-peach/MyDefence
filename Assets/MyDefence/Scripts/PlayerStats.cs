using UnityEngine;

namespace MyDefence
{
    //플레이어의 속성들을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Field
        //소지금
        private static int money;

        //초기 소지금
        [SerializeField]
        private int startMoney = 400;
        #endregion

        #region Property
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }
        #endregion

        //소지금 초기값 400
        private void Start()
        {
            //초기화
            //초기 소지금 지급 400
            money = startMoney;
            Debug.Log($"소지금 {startMoney}원을 지급했습니다");
        }

        //벌기, 쓰기, 소지금 확인 함수 만들기
        public static void AddMoney(int amount)
        {
            money += amount;
        }

        public static bool UseMoney(int amount)
        {
            if (money < amount)
            {
                Debug.Log("돈 없다 이 놈아");
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
    }

}
