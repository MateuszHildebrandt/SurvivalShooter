using UnityEngine;

namespace UI
{
    public class OptionsUI : MonoUI<OptionsUI>
    {
        #region OnClick
        public void OnClickReturn() => MainMenuUI.I.EnterState();
        #endregion
    }
}
