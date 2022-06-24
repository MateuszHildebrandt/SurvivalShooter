using UI;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class InstallerMainMenu : MonoInstaller
    {
        [Header("References")]
        [SerializeField] GameObject optionsUI;

        public override void InstallBindings()
        {
            Container.Bind<OptionsUI>().FromComponentOn(optionsUI).AsSingle();
        }
    }
}
