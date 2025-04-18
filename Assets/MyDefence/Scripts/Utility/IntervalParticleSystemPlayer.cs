using System.Collections;
using System.Threading;
using UnityEngine;

namespace MyDefence
{

    public class IntervalParticleSystemPlayer : MonoBehaviour
    {
        #region Field
        //타이머 시간마다 플레이할 파티클 시스템
        public ParticleSystem particleSystemToPlay;

        //타이머
        public float interval;
        private float timeCount = 0f;
        #endregion

        private void Start()
        {
            //초기화
            timeCount = 0f;
        }



        private void Update()
        {
            timeCount += Time.deltaTime;
            if (timeCount >= interval)
            {
                //타이머 기능 구현
                PlayParticleEffect();

                //타이머 초기화
                timeCount = 0f;
            }
        }

        //파티클 이펙트를 플레이한다
        void PlayParticleEffect()
        {
            particleSystemToPlay.Play();
        }

    }

}
