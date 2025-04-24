using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    //골드를 관리하는 클래스
    public class MoneyTest : MonoBehaviour
    {
        #region Field
        //소지금
        private int gold;

        [SerializeField]
        private int startGold;

        private int playerMoney;

        //UI 잔여소지금
        public TextMeshProUGUI goldText;

        //Button UI
        public Button button1000;
        public Button button9000;
        #endregion

        private void Start()
        {
            //초기화 - 게임 처음 시작할 때 startGold로 초기화
            //"GameMoney"이름으로 저장된 소지금 있는지 확인
            gold = PlayerPrefs.GetInt("GameMoney", startGold);
            //Debug.Log($"소지금 {startGold}원을 지급했습니다");

            /*if(PlayerPrefs.GetInt("GameMoney") == 0)
            {
                //소지금 지급
                gold = startGold;
                Debug.Log($"소지금 {startGold}원을 지급했습니다");
            }
            else
            {
                gold = PlayerPrefs.GetInt("GameMoney");
            }*/
            //ex 버튼 이미지 색깔 바꾸기
            //button1000.image.color = Color.blue;
        }

        private void Update()
        {
            //아이템 구매가 가능하면 버튼 이미지는 white,
            //불가능하면 red

            //UI 연결
            goldText.text = $"{gold} Gold";

            button1000.interactable = HasGold(1000);
            /*if (HasGold(1000)) button1000.image.color = Color.white;
            else button1000.image.color = Color.red;*/
            button9000.interactable = HasGold(9000);
            /*if (HasGold(9000)) button9000.image.color = Color.white;
            else button9000.image.color = Color.red;*/

        }

        //Gold를 연산하는 함수
        //돈을 번다: 사냥, 퀘스트 클리어, 캐쉬 구매, 이벤트 보상...
        public void AddGold(int amount)
        {
            gold += amount;
            PlayerPrefs.SetInt("GameMoney", gold);
        }

        //돈을 쓴다 : 아이템 구매, 기구 사용...
        //돈이 부족하면 돈을 사용하지 않고 return false;
        //돈이 충분하면 돈을 사용하고 return true;
        public bool UseGold(int amount)
        {
            //소지금 체크
            if (gold < amount)
            {
                Debug.Log("돈 없다 이 놈아");
                return false;
            }

            gold -= amount;
            PlayerPrefs.SetInt("GameMoney", gold);
            return true;
        }

        //소지금 체크 : amount만큼 소지금을 가지고 있는지 여부
        public bool HasGold(int amount)
        {
            if (gold < amount)
            {
                return false;
            }

            return true;
        }

        //버튼 3개 클릭 시 호출되는 함수 3개 만들고 각 버튼에 연결하세요
        //버튼 클릭 시 Gold 계산하고 출력하세요
        public void SaveButton()
        {
            AddGold(1000);
            Debug.Log($"1000 Gold Save, 현재 소지금 : {gold}");
            
        }

        public void Item1000()
        {
            if(UseGold(1000)) Debug.Log($"1000 Item 구매, 현재 소지금 : {gold}");
        }

        public void Item9000()
        {
            if(UseGold(9000)) Debug.Log($"9000 Item 구매, 현재 소지금 : {gold}");
        }
    }

}

/*
MoneyTest

1. 시작하면 소지금이 있는지 체크 - keyName = "GameMoney"
- 없는 경우 : 1000원 지급
- 있는 경우 : 저장된 값 가져와서 gold 값으로 설정

2. 화면 상단에 소지금 표시 ( 1000 Gold )
3. 버튼 3개
    1) 저축 버튼 : 1000원 저축, 버튼 클릭 시 +1000, "1000 Gold Save" 출력 - gold save
    2) 구매 버튼 : 1000원 아이템 구매, 버튼 클릭 시 -1000, "1000 Item 구매" 출력 - gold save
    3) 구매 버튼 : 9000원 아이템 구매, 버튼 클릭 시 -9000, "9000 Item 구매" 출력 - golde save

구매 버튼 : 아이템 구매가 가능하면 버튼 이미지는 White,
           소지금이 부족하여 구매가 불가능하면 버튼 이미지는 red,
           구매가 불가능하면 구매 버튼을 클릭해도 구매가 불가능해야 한다
 
 */