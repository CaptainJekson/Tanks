using Code.MapModule.Configs;
using Code.MapModule.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.MapModule.Controllers
{
    public class MapLoaderController
    {
        private MapsCollectionConfig _mapsCollectionConfig;
        
        public MapLoaderController(
            MapsCollectionConfig mapsCollectionConfig)
        {
            _mapsCollectionConfig = mapsCollectionConfig;
        }

        public void LoadMap(MapType mapType)
        {
            if (!_mapsCollectionConfig.TryGetMapConfigByType(mapType, out var mapConfig))
            {
                Debug.LogError($"[SceneLoadingController.InitializeMap] no map config for map type: {mapType}");
                return;
            }

            SceneManager.LoadScene(mapConfig.Scene.name, LoadSceneMode.Additive);
        }
    }
}