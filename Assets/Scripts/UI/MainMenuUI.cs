using State;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MainMenuUI : MonoUI
    {
        [Header("References")]
        [SerializeField] Button continueButton;

        private OptionsUI _optionsUI;

        [Inject]
        private void Constructor(OptionsUI optionsUI)
        {
            _optionsUI = optionsUI;
        }

        #region OnClick
        public void OnClickContinue()
        {
            //TODO: load last file
        }

        public void OnClickNewGame() => SceneManager.LoadScene(1);

        public void OnClickOptions() => _optionsUI.EnterState();

        public void OnClickExit() => Application.Quit();
        #endregion

        #region StateMachine
        public override void OnEnter()
        {
            base.OnEnter();
            continueButton.interactable = false; //TODO: detect save files
        }
        #endregion
    }
}
