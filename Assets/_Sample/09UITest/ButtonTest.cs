using UnityEngine;

namespace Sample
{
    //버튼 기능 테스트
    public class ButtonTest : MonoBehaviour
    {
        //Fire 버튼 클릭시 (실행)호출되는 함수
        public void FireButton()
        {
            Debug.Log("아 빵애예요!!!");
        }

        //Jump 버튼 클릭시 "플레이어가 점프하였습니다" 출력
        public void JumpButton()
        {
            Debug.Log("호잇짜!");
        }

    }

}
