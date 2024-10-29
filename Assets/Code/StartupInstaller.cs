using Code.MapModule;
using Code.TankModule;
using Code.UiModule;
using Code.UiModule.Views;
using UnityEngine;
using Zenject;

namespace Code
{
    public class StartupInstaller : MonoInstaller
    {
        [SerializeField] private UiRoot _uiRoot;
        
        public override void InstallBindings()
        {
            Container.Bind<UiRoot>().FromInstance(_uiRoot).AsSingle().NonLazy();

            MapInstaller.Install(Container);
            TankInstaller.Install(Container);
            
            UiInstaller.Install(Container);
        }
    }
}
