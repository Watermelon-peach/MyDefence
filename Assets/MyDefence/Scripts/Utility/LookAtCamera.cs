using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    //카메라를 향해 바라본다
    public class LookAtCamera : MonoBehaviour
    {
        #region Field
        private Camera m_MainCamera;
        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            m_MainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            //transform.LookAt(m_MainCamera.transform);
            //현재 나의 포지션 x와 동일한 위치에 가상의 타겟을 만들어 바라본다
            Vector3 target = new Vector3(transform.position.x, m_MainCamera.transform.position.y, m_MainCamera.transform.position.z);
            transform.LookAt(target);
            //뭐가 다른거지?
        }
    }

}
