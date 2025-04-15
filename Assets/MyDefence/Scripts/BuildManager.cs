using UnityEngine;

namespace MyDefence
{
    
    //타워 건설을 관리하는 싱글톤 클래스
    public class BuildManager : MonoBehaviour
    {
        #region Singleton
        private static BuildManager instance;

        public static BuildManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;


        }
        #endregion

        #region Field
        //타일에 설치할 타워 프리팹 오브젝트를 저장하는 변수
        private TowerBluePrint towerToBuild;

        public TileUI tileUI;

        //선택된 타일
        private Tile selectTile;
        #endregion

        #region Property
        //타워 건설 비용을 체크: 부족하면 true
        public bool NotEnoughMoney
        {
            get { return PlayerStats.Money < towerToBuild.cost; }
        }

        //건설할 타워가 있는지 체크, 건설할 타워를 선택하지 않았을 때
        public bool CannotBuild
        {
            get { return towerToBuild == null; }
        }
        #endregion

        private void Start()
        {
            //초기화
            //towerToBuild = machineGunPrefab;
        }
        //타일에 설치할 타워 wjdqhfmf 얻어오기
        public TowerBluePrint GetTowerToBuild()
        {
            return towerToBuild;
        }

        //타일에 설치할 타워 프리팹 오브젝트 저장하기
        public void SetTowerToBuild(TowerBluePrint tower)
        {
            towerToBuild = tower;
        }

        //타워가 설치된 타일을 선택
        public void SelectTile(Tile tile)
        {
            //같은 타일 선택하면 선택해제
            //이전에 선택한 타일과 지금 선택한 타일이 같으면 선택해제
            if(selectTile == tile)
            {
                DeselectTile();
                return;
            }

            selectTile = tile;
            tileUI.ShowTileUI(selectTile);
        }

        //선택된 타일 해제
        public void DeselectTile()
        {
            tileUI.HideTileUI();
            selectTile = null;
        }
    }

}
