using UnityEngine;

namespace Solid.OpenClose
{
    //모든 도형의 부모 클래스
    public abstract class Shape
    {
        //도형의 면적을 구해서 반환하는 함수
        public abstract float CalculateArea();      
    }
    
    public class Rectangle : Shape
    {
        private float width;
        private float height;

        //도형의 면적을 구해서 반환하는 함수
        public override float CalculateArea()
        {
            return width * height;
        }
    }

    public class Circle : Shape
    {
        private float radius;
        //도형의 면적을 구해서 반환하는 함수
        public override float CalculateArea()
        {
            return radius * radius * Mathf.PI;
        }

    }
}
