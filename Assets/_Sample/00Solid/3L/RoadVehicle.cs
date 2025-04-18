using UnityEngine;

namespace Solid
{
    public class RoadVehicle : MonoBehaviour, IMoveable, ITurnable
    {
        public void GoBack()
        {
            //도로를 후진하는 기능 구현
        }

        public void GoForward()
        {
            //도로를 전진하는 기능 구현
        }

        public void TurnLeft()
        {
            //도로를 좌회전하는 기능 구현
        }

        public void TurnRight()
        {
            //도로를 우회전하는 기능 구현
        }
    }

    public class CarR : RoadVehicle
    {

    }

    public class Truck : RoadVehicle
    {

    }
}
