using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    public class Rocket : Bullet
    {
        #region Field
        //데미지 영역
        public float damageRange = 3.5f;
        //적 태그
        public string enemyTag = "Enemy";
        #endregion

        //타겟을 맞혀 폭발하여 데미지 영역에 있는 적 킬 - rocket
        protected override void HitTarget()
        {
            //타격 이펙트 효과
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //폭발
            Debug.Log("펑");
            Explosion();
            
            //탄환 킬
            Destroy(this.gameObject);
        }

        //폭발 - 대미지영역(3.5f)에 있는 적을 찾아 킬
        private void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == enemyTag)
                {
                    Destroy(hitCollider.gameObject);
                }
            }
        }

        //기즈모 데미지 영역 그리기
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }


    }

}
