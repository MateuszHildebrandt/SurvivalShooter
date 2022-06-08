using State;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoUI<MainMenuUI>, IStateExtension
    {
        [Header("References")]
        [SerializeField] Button continueButton;

        #region OnClick
        public void OnClickContinue()
        {
            //TODO: load last file
        }

        public void OnClickNewGame() => SceneManager.LoadScene(1);

        public void OnClickOptions() => OptionsUI.I.EnterState();

        public void OnClickExit() => Application.Quit();
        #endregion

        #region StateMachine
        void IStateExtension.OnEnter()
        {
            continueButton.interactable = false; //TODO: detect save files
        }

        void IStateExtension.OnExit() { }
        #endregion
    }
}
