using UnityEngine;

namespace Sample
{
    public class TorchFlameAnimation : MonoBehaviour
    {
        #region Variables
        //라이트 레거시 애니메이션
        public Animation animation;

        //애니메이션 타이머
        [SerializeField] private float animTimer = 1f;
        private float timeCount = 0f;
        #endregion

        private void Start()
        {
            InvokeRepeating("RandomAnimation", 1f, 1f);
        }
        private void Update()
        {
            //1초마다 세개 중에 하나를 랜덤하게 애니메이션을 플레이
            timeCount += Time.deltaTime;
            if (timeCount >= animTimer)
            {
                //타이머 기능 호출

                //타이머 초기화
                timeCount = 0f;
            }
        }
        void RandomAnimation()
        {
            int random = Random.Range(1, 4);
            /*switch (random)
            {
                case 0:
                    animation.Play("FlameAnim01");
                    Debug.Log("1번 애니메이션");
                    break;
                case 1:
                    animation.Play("FlameAnim02");
                    Debug.Log("2번 애니메이션");
                    break;
                case 2:
                    animation.Play("FlameAnim03");
                    Debug.Log("3번 애니메이션");
                    break;
            }*/
            animation.Play($"FlameAnim0{random}");
            Debug.Log($"{random}번 애니메이션");
        }
    }

}
