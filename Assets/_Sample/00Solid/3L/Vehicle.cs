using UnityEngine;

namespace Solid
{
    //탈 것에 대한 기능 구현 클래스
    public class Vehicle : MonoBehaviour
    {
        #region Field
        public float speed;
        public Vector3 direction;
        #endregion

        public virtual void GoForward()
        {
            //앞으로 직진 구현

        }
        
        public virtual void GoBack()
        {
            //뒤로 후진 구현

        }

        public virtual void TurnLeft()
        {
            //좌회전 구현
        }

        public virtual void TurnRight()
        {
            //우회전 구현
        }
    }

    //Vehicle을 상속받는 Car 클래스
    public class Car : Vehicle
    {
        public override void GoForward()
        {
            //자동차가 전진한다 구현

        }

        public override void GoBack()
        {
            //자동차가 후진한다
        }

        public override void TurnLeft()
        {
            //자동차가 좌회전한다
        }

        public override void TurnRight()
        {
            //자동차가 우회전 한다
        }
    }

    //Vehicle을 상속받는 Car 클래스
    public class Train : Vehicle
    {

        public override void GoForward()
        {
            //기차가 전진한다 구현
        }
        public override void GoBack()
        {
            //기차가 후진한다 구현   
        }

        public override void TurnLeft()
        {
            //empty
        }

        public override void TurnRight()
        {
            //empty
        }
    }
}
