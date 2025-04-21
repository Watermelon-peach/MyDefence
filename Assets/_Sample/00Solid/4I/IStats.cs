using UnityEngine;

namespace Solid.Interface
{
    //유닛의 속성들을 정의
    public interface IStats
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
    }

}
