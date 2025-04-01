using Sample;
using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        #region Field
        //타겟 오브젝트
        private Transform target;
        //이동속도
        public float moveSpeed = 30f;
        #endregion

        public void SetTarget(Transform _target)
        {
            this.target = _target;
        }

        // Update is called once per frame
        void Update()
        {
            if(target == null)
            {
                Destroy(this.gameObject);
                return;
            }
            //이동하기
            //dir.magnitude : 두 벡터간의 거리
            Vector3 dir = target.position - this.transform.position;
            float distanceThisFrame = Time.deltaTime * moveSpeed;   //이번 프레임에 이동하는 거리
            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        }

        //타겟을 맞히다
        void HitTarget()
        {
            Debug.Log("끄앙");
            //타겟 킬
            Destroy(target.gameObject);
            //탄환 킬
            Destroy(this.gameObject);
        }
    }

}
