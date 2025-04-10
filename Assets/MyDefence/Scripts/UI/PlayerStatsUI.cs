using UnityEngine;
using TMPro;

namespace MyDefence
{
    public class PlayerStatsUI : MonoBehaviour
    {
        #region Field
        //Life Text UI
        public TextMeshProUGUI livesText;
        #endregion

        // Update is called once per frame
        void Update()
        {
            livesText.text = PlayerStats.Lives.ToString();
        }
    }

}
