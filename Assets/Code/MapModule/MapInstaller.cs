using Code.MapModule.Configs;
using Code.MapModule.Controllers;
using Zenject;

namespace Code.MapModule
{
    public class MapInstaller : Installer<MapInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MapsCollectionConfig>().FromScriptableObjectResource("Configs/MapModule/MapsCollectionConfig")
                .AsSingle();
            
            Container.Bind<MapLoaderController>().AsSingle();
        }
    }
}