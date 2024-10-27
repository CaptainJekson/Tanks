using Code.MapModule.Configs;
using Code.MapModule.Controllers;
using Code.UiModule.Enums;
using Code.UiModule.Views.MainMenu;
using UnityEngine;

namespace Code.UiModule.Controllers
{
    public class MainMenuController
    {
        private UiCreatorController _creatorController;
        private MapsCollectionConfig _mapsCollectionConfig;
        private MapLoaderController _mapLoaderController;

        private MainMenuGui _instance;

        public MainMenuController(
            UiCreatorController uiCreatorController,
            MapsCollectionConfig mapsCollectionConfig,
            MapLoaderController mapLoaderController)
        {
            _creatorController = uiCreatorController;
            _mapsCollectionConfig = mapsCollectionConfig;
            _mapLoaderController = mapLoaderController;

            Initialize();
        }

        private void Initialize()
        {
            _instance = _creatorController.Open<MainMenuGui>(UiType.Windows);
            
            _instance.StartGameButton.onClick.AddListener(StartGame);

            foreach (var mapConfigByType in _mapsCollectionConfig.MapConfigsByType)
            {
                var createdItem = Object.Instantiate(_instance.MapItemTemplate, _instance.MapItemParent);

                createdItem.MapType = mapConfigByType.MapType;
                createdItem.Name.text = mapConfigByType.MapConfig.Name;
                createdItem.MainImage.sprite = mapConfigByType.MapConfig.Icon;
                createdItem.Toggle.group = _instance.ToggleMapGroup;
                createdItem.Toggle.onValueChanged.AddListener(isOn =>
                {
                    if (!isOn)
                    {
                        return;
                    }

                    _instance.SelectedMapType = createdItem.MapType;
                });
            }
        }

        private void StartGame()
        {
            _mapLoaderController.LoadMap(_instance.SelectedMapType);
            _creatorController.Close<MainMenuGui>();
        }
    }
}