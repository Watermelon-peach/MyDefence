using UnityEngine;

namespace Solid
{
    public class RailVehicle : MonoBehaviour, IMoveable
    {
        public void GoBack()
        {
            //철도 위르 ㄹ후진한다 기능 구현
        }

        public void GoForward()
        {
            //철도 위를 전진한다 기능 구현
        }
    }

    //RailVehicle 상속받는 기차 구현
    public class TrainR : RailVehicle
    {

    }

    //RailVehicle 상속받은 지하철 구현
    public class Subway : RailVehicle
    {
        
    }
}
