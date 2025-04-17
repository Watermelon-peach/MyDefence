using UnityEngine;

namespace Solid.OpenClose
{
    public class AreaCalculator : MonoBehaviour
    {
        public Rectangle rectangle;
        public Circle circle;

        //매개변수로 받은 도형의 면적 구해서 반환하는 함수
        public float GetShapeArea(Shape shape)
        {
            return shape.CalculateArea();
        }

        private void Start()
        {
            float rectArea = GetShapeArea(rectangle);
            float circArea = GetShapeArea(circle);
        }
        /*//매개변수로 받은 사각형 도형의 면적 구해서 반환하는 함수
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.CalculateArea();
        }*/
    }

}
