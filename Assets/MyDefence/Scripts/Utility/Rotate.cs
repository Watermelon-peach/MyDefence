using UnityEngine;

namespace MyDefence
{
    //오브젝트를 회전시키는 클래스
    public class Rotate : MonoBehaviour
    {
        //회전축과, 스피드 설정
        public Vector3 rotationSpeed;

        private void Update()
        {
            transform.localEulerAngles += rotationSpeed;
        }
    }

}
