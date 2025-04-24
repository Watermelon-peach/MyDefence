using UnityEngine;

namespace Sample
{
    //팩토리 메서드 패턴
    //팩토리 메서드 - 생성하는 메서드를 추상화한다
    public interface IMonsterFactory
    {
        //몬스터를 반환하는 팩토리 메서드
        public Monster CreateMonster();
    }

    //슬라임을 생성하는 전용 팩토리
    public class SlimeFactory : IMonsterFactory
    {
        public int count = 0;

        public Monster CreateMonster()
        {
            return new Slime();
        }

        //슬라임 생성 개수 카운팅
        public void SlimeCount() => count++;
    }

    //좀비를 생성하는 전용 팩토리
    public class ZombieFactory : IMonsterFactory
    {
        public Monster CreateMonster()
        {
            return new Zombie();
        }

        public void AddSomething()
        {
            Debug.Log("다른 무언가 추가");
        }
    }

    //고블린 팩토리....


    //스켈레톤 전용 공장
    public class SkeletonFactory : IMonsterFactory
    {
        public Monster CreateMonster()
        {
            return new Skeleton();
        }
    }
}
