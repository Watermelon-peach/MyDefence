using UnityEngine;
using UnityEngine.UI;

namespace MyDefence
{
    public class ImageTest : MonoBehaviour
    {
        #region Field
        //스킬 버튼
        public Button skillButton;
        public Image skillButtonImage;
        //쿨타이머
        public float timeCount;
        [SerializeField] private float coolTime = 5f;

        //쿨 타임 체크
        private bool isCharge = false;
        #endregion

        private void Start()
        {
            timeCount = 0f;
            isCharge = true;
        }
        private void Update()
        {
            if (isCharge)
                return;

            timeCount += Time.deltaTime;
            if (timeCount >= coolTime)
            {
                //타이머 기능
                skillButton.interactable = true;

                //타이머 초기화
                isCharge = true;
            }

            //countdown : 0 -> 5, fillAmount 0 -> 1 (100%, 소수점, 분수)
            //백분율 : (현재값량: timeCount) / (총값량: 3)
            skillButtonImage.fillAmount = timeCount / coolTime;

        }
        //스킬 버튼 클릭 시 호출되는 함수
        public void SkillUse()
        {
            skillButton.interactable = false;

            timeCount = 0f;
            isCharge = false;
        }
    }
}

