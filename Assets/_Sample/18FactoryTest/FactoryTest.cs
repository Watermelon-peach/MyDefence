using UnityEngine;

namespace Sample
{
    public class FactoryTest : MonoBehaviour
    {
        private void Start()
        {
            //심플 팩토리 객체 생성
            /*MonsterFactory monsterFactory = new MonsterFactory();

            //슬라임 생성
            Monster slime = monsterFactory.CreateMonster(MonsterType.M_Slime);
            slime.Attack();

            Monster zombie = monsterFactory.CreateMonster(MonsterType.M_Zombie);
            zombie.Attack();

            Monster slime2 = monsterFactory.CreateMonster(MonsterType.M_Goblin);
            slime2.Attack();*/

            //팩토리 메서드 패턴
            //슬라임 전용 공장
            SlimeFactory slimeFactory = new SlimeFactory();
            Monster slime = slimeFactory.CreateMonster();   //슬라임 생산
            slimeFactory.SlimeCount();                      //생산한 슬라임 카운트
            Debug.Log($"slime: {slimeFactory.count}");
            slime.Attack();

            //좀비 전용 공장
            ZombieFactory zombieFactory = new ZombieFactory();
            Monster zombie = zombieFactory.CreateMonster(); //좀비 생산
            zombieFactory.AddSomething();
            zombie.Attack();

            //스켈레톤 전용 공장
            SkeletonFactory skeletonFactory = new SkeletonFactory();
            Monster skeleton = skeletonFactory.CreateMonster(); //스켈레톤 생상
            skeleton.Attack();
        }
    }
}


