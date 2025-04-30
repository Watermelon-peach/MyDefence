using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    public class CameraControllerNew : MonoBehaviour
    {
        #region Field
        //카메라 이동속도
        public float moveSpeed = 10f;

        //카메라 스크롤 스피드
        public float scrollSpeed = 10f;
        public float scrollMin = 10f;
        public float scrollMax = 20f;

        //New InputAction 클래스 객체
        private InputActionTest inputActions;

        //인풋값을 받아오는 변수
        private Vector2 inputVector;
        #endregion

        /*#region NewInput - 1번 Script
        private void Awake()
        {
            //참조 - New InputAction 클래스 객체
            inputActions = new InputActionTest();
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        private void Update()
        {
            //키 입력 값에 따른 카메라 이동
            inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            //마우스 포인터 위치에 따른 카메라 이동
            //InputAction에서 값 읽어오기
            //Vector2 mousePos = inputActions.Camera.MousePos.ReadValue<Vector2>();
            //System에서 마우스 정보값 읽어오기
            Vector2 mousePos = Mouse.current.position.ReadValue();
            float mouseX = mousePos.x;
            float mouseY = mousePos.y;

            if (mouseY >= Screen.height - 30 && mouseY <= Screen.height)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseY <= 30 && mouseY >= 0)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX >= Screen.width - 30 && mouseX <= Screen.width)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX <= 30 && mouseX >= 0)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
        }
        #endregion*/

        /*#region NewInput - 2번 SendMessage
        private void Update()
        {
            //키 입력 값에 따른 카메라 이동
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
        }

        public void OnMove(InputValue value)
        {
            inputVector = value.Get<Vector2>();
        }
        #endregion*/

        #region NewInput - 3번 Event
        private void Update()
        {
            //키 입력 값에 따른 카메라 이동
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
        }
        public void Move(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }
        #endregion

    }

}

/*
New Input System에서 유저 인풋값 가져오기 : 3가지
1. 스크립트를 이용하여 가져오기 : InputAction을 Class 파일로 만들어서 처리
2. SendMessage 방법 : PlayerInput 컴포넌트를 이용하여 처리
    - SendMessage를 통해 호출하는 메서드 만드는 방법
     : 함수 이름 - On + Action이름
     : 매개변수 InputValue value

3. Event 등록 방법 : PlayerInput 컴포넌트를 이용하여 처리
    - Uniyt Events에 함수르 등록하여 메서드를 호출하는 방법
    - 등록메서드 만드는 방법
     : 함수 이름 - x
     : 매개변수 InputAction.CallbackContext context

 
 */