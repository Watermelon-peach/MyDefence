using UnityEngine;
using UnityEngine.UI;
namespace MyDefence
{
    public class Enemy : MonoBehaviour
    {
        //필드
        #region Field
        //체력
        private float health;
        
        //체력 초기값
        [SerializeField]private float startHealth = 100f;

        //이동 속도
        public float moveSpeed = 5f;

        //이동 속도 - origin
        private float startMoveSpeed;

        private Vector3 targetPosition;
        //wayPoint 오브젝트의 트랜스폼 객체
        private Transform target;
        //wayPoints 배열의 인덱스
        private int wayPointIndex = 0;

        //리워드 골드
        [SerializeField]private int rewardGold = 50;

        //죽음 이펙트 프리팹
        public GameObject deathEffectPrefab;

        //체력바 UI
        private bool isTakeDamage = false;
        public GameObject healthBarUI;
        public Image healthBarImage;

        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            wayPointIndex = 0;
            target = WayPoints.wayPoints[wayPointIndex];
            health = startHealth;
            startMoveSpeed = moveSpeed;
            isTakeDamage = false;
        }

        // Update is called once per frame
        void Update()
        {
            //이동 구현
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            //target 도착 판정
            float distance = Vector3.Distance(target.position, this.transform.position);
            if (distance <= 0.1f)
            {
               
                //다음 타겟 셋팅
                GetNextTarget();
            }

            //속도 원복
            moveSpeed = startMoveSpeed;

           
        }

        //다음 타겟 포지션 얻어오기
        void GetNextTarget()
        {
            //종점 도착 판정
            if (wayPointIndex == WayPoints.wayPoints.Length-1)
            {
                Debug.Log("종점 도차쿠");
                //플레이어의 라이프 소모
                PlayerStats.UseLives(1);

                Destroy(this.gameObject);
                return;
            }
            wayPointIndex++;
            target = WayPoints.wayPoints[wayPointIndex];   
        }

        //대미지 처리
        public void TakeDamage(float damage)
        {
            health -= damage;

            //대미지 효과(VFX, SFX)
            //체력바 UI
            healthBarImage.fillAmount = health / startHealth;

            //죽음 체크
            if (health <= 0f)
            {
                Die();
            }
        }

        //죽음 처리
        private void Die()
        {
            //보상, 벌
            //리워드 50gold 지급
            PlayerStats.AddMoney(rewardGold);

            //VFX,SFX
            //죽는 파티클 이펙트 만들어서 처리
            GameObject effectGo = Instantiate(deathEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //킬
            Destroy(this.gameObject, 0f);
        }

        //매개변수로 입력받은 감속률만큼 속도 감속
        public void Slow(float rate)
        {
            moveSpeed = startMoveSpeed * (1 - rate);
        }
    }

}
