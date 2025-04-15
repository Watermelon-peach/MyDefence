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
            Explosion();
            
            //탄환 킬
            Destroy(this.gameObject);
        }

        //폭발 - 대미지영역(3.5f)에 있는 적을 찾아 킬
        //폭발지점으로부터 각 Enemy들과의 거리를 구하여 거리에 반비례하여 대미지 주기
        private void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == enemyTag)
                {
                    //거리 구하기
                    float distance = Vector3.Distance(this.transform.position, hitCollider.transform.position);
                    //거리 반비례로 대미지 구하기
                    float damage = attackDamage * ((damageRange - distance) / damageRange);

                    Enemy enemy = hitCollider.GetComponent<Enemy>();
                    if(enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }
            }
        }

        //매개변수로 들어온 타겟에게 대미지 주기
        /*private void Damage(GameObject target)
        {
            float distance = Vector3.Distance(target.transform.position, this.transform.position);
            //attackDamage에 거리/범위를 곱한만큼 타겟의 Health 감산
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null) enemy.TakeDamage(attackDamage * (distance/damageRange));
        }*/
        //기즈모 데미지 영역 그리기
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }


    }

}
