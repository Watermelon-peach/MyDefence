using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class LevelClearUI : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        [SerializeField] private string nextLevel = "Level02";
        #endregion


        public void Contiune()
        {
            if (nextLevel == "")
            {
                nextLevel = "LevelSelect";
            }
            fader.FadeTo(nextLevel);
        }

        public void Menu()
        {
            fader.FadeTo("MainMenu");
        }
    }

}
