using UnityEngine;

namespace MyDefence
{
    public class GameManager : MonoBehaviour
    {
        #region Field
        [SerializeField]private bool isCheat = false;
        #endregion

        private void Update()
        {
            //Cheating
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
        }

        //Cheating
        //M키를 누르면 10만 골드 지급
        void ShowMeTheMoney()
        {
            if (!isCheat)
                return;

            PlayerStats.AddMoney(100000);
        }

        //레벨업 치팅
        void LevelUpCheat()
        {
            //PlayerStats.LevelUp();
        }

        //...
    }

}
