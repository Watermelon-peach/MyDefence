using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    //맵의 타일을 관리하는 클래스
    public class Tile : MonoBehaviour
    {
        #region Field
        //마우스를 올려놓으면 변하는 색깔
        //public Color hoverColor;
        public Material hoverMaterial;
        //돈 없을 때
        public Material noMoneyMaterial;

        //타일의 원래 색깔
        //private Color startColor;
        private Material startMaterial;

        

        //타일의 Renderer
        private Renderer renderer;

        //BuildManager 객체
        private BuildManager buildManager;

        //타일에 설치한 타워 오브젝트
        private GameObject tower;

        //타일에 설치한 타워의 정보
        private TowerBluePrint bluePrint;

        //타워 건설 이펙트 프리팹
        public GameObject buildEffectPrefab;
        #endregion

       
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            buildManager = BuildManager.Instance;
            renderer = this.transform.GetComponent<Renderer>();

            //초기화
            //startColor = renderer.material.color;
            startMaterial = renderer.material;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseDown()
        {
            //타일 위에 UI가 있는지 체크
            if(EventSystem.current.IsPointerOverGameObject() == true)
            {
                return;
            }

            //저장된 프리팹 체크
            if (buildManager.GetTowerToBuild() == null)
            {
                Debug.Log("설치할 타워가 없습니다");
                return;
            }

            //현재 타일에 타워가 설치되었는지 체크
            if (tower != null)
            {
                Debug.Log("타워를 설치할 수 없습니다");
                return;
            }

            //타워 건설
            BuildTower();
        }

        //타워 건설
        void BuildTower()
        {
            //건설비용 체크
            if (buildManager.NotEnoughMoney)
                return;

            //건설할 타워의 정보를 저장
            bluePrint = buildManager.GetTowerToBuild();

            int buildCost = buildManager.GetTowerToBuild().cost;

            //돈 계산
            PlayerStats.UseMoney(bluePrint.cost);

            //Debug.Log("이 스크립트가 붙어있는 타일 위에 터렛을 설치");
            tower = Instantiate(bluePrint.towerPrefab, this.transform.position, Quaternion.identity);

            //건설 이펙트 생성
            GameObject effectGo = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.Euler(-90f, 0f, 0f));
            Destroy(effectGo, 2f);


            //초기화 - 저장된 타워 프리팹 초기화
            buildManager.SetTowerToBuild(null);
        }

        private void OnMouseEnter()
        {
            //타일 위에 UI가 있는지 체크
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                return;
            }

            if (buildManager.CannotBuild)
            {
                //Debug.Log("타워를 선택하지 않았습니다");
                return;
            }

            //현재 타일에 타워가 있는지 체크
            if (tower != null)
            {
                Debug.Log("타워를 설치할 수 없습니다");
                return;
            }
            //renderer.material.color = hoverColor;
            renderer.material = (buildManager.NotEnoughMoney) ? noMoneyMaterial : hoverMaterial;
        }

        private void OnMouseExit()
        {
            //renderer.material.color = startColor;
            //renderer.material.color = Color.white;
            renderer.material = startMaterial;
        }
    }

}
