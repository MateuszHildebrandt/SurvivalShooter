using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuUI : MonoUI<MainMenuUI>
    {
        #region OnClick
        public void OnClickNewGame()
        {
            SceneManager.LoadScene(1);
        }

        public void OnClickOptions()
        {

        }

        public void OnClickExit() => Application.Quit();
        #endregion
    }
}
