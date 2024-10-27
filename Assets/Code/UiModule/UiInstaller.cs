using Code.UiModule.Configs;
using Code.UiModule.Controllers;
using Zenject;

namespace Code.UiModule
{
    public class UiInstaller : Installer<UiInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UiHudConfig>().FromScriptableObjectResource("Configs/UiModule/UiHudConfig")
                .AsSingle();
            
            Container.Bind<UiWindowConfig>().FromScriptableObjectResource("Configs/UiModule/UiWindowConfig")
                .AsSingle();
            
            Container.Bind<UiPopupConfig>().FromScriptableObjectResource("Configs/UiModule/UiPopupConfig")
                .AsSingle();

            Container.Bind<UiCreatorController>().AsSingle();
            Container.Bind<MainMenuController>().AsSingle().NonLazy();
        }
    }
}