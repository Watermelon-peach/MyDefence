using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class Title : MonoBehaviour
    {
        //타이틀 씬을 관리하는 클래스
        #region Field
        //애니키 UI 오브젝트
        public GameObject anykeyText;

        //다음으로 이동하려는씬 이름
        [SerializeField] private string sceneToLoad = "MainMenu";
        //애니키 UI를 보여주고 있는지 체크
        private bool isShow = false;

        //타이머
        [SerializeField]
        private float titleTimer = 2f;
        private float timeCount;

        //씬 페이더
        public SceneFader fader;

        //======================Sample======================
        private bool isOneTime = false; //실행 안 했으면 false, 한버이라도 실행했으면 true
        [SerializeField]
        private float spawnDelay = 2f;  //생성 딜레이 2초
        private float spawnTime;        //몬스터 생성한 시간 저장
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //초기화
            //timeCount = 0f;
            //anykeyText.SetActive(false);
            //spawnTime = Time.time;
            isShow = false;
            //InvokeRepeating 처음 시작시 1초 딜레이 후 2초간격으로 몬스터 생성
            //InvokeRepeating("SpawnMonster", 1f, 2f);

            //지연 - Invoke
            //Invoke("SpawnMonster", spawnDelay);

            //지연 - Coroutine
            //StartCoroutine(Spawn());
            StartCoroutine(GameStart());
        }

        // Update is called once per frame
        void Update()
        {
            //아무 키를 누르면 메인메뉴 씬으로 이동
            if (Input.anyKeyDown && isShow)
            {
                //현재 대기하고 있는 모든 코루틴 함수 정지
                StopAllCoroutines();

                GotoMenu();
            }
            //내가 처음에 쓴 답
            /*timeCount += Time.deltaTime;
            if (timeCount <= titleTimer) return;
            anykeyText.SetActive(true);

            if (Input.anyKeyDown || timeCount >= titleTimer + 10f)
            {
                SceneManager.LoadScene(sceneToLoad);
            }*/

            //한번만 실행하는법
            /*if(isOneTime == false)
            {
                timeCount += Time.deltaTime;
                //...
            if(조건달성시) isOneTime = true;
            }*/

            /*//Time.time 현재시간을 저장하고 딜레이시간만큼 지났는지 체크
            if ((spawnTime+spawnDelay) <= Time.time)
            {
                //반복 실행문
                SpawnMonster();

                //타이머 초기화 : 현재시간을 다시 저장
                spawnTime = Time.time;
            }*/
        }

        

        private void ShowAnyKey()
        {
            isShow = true;
            anykeyText.SetActive(isShow);
        }

        private void GotoMenu()
        {
            fader.FadeTo(sceneToLoad);
        }

        IEnumerator GameStart()
        {

            yield return new WaitForSeconds(titleTimer);
            ShowAnyKey();

            yield return new WaitForSeconds(10f);
            GotoMenu();
        }

        //======================Sample======================
        IEnumerator Spawn()
        {
            //spawnDelay만큼 지연
            yield return new WaitForSeconds(spawnDelay);

            SpawnMonster();
        }

        private void SpawnMonster()
        {
            Debug.Log("Spawn Monster!!");
        }
    }

}

/*
타이머
- 1회성
- 반복
*/