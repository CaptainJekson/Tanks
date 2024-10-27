using Code.MapModule.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UiModule.Views.MainMenu
{
    public class MainMenuGui : GuiComponent
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private MapGuiItem _mapItemTemplate;
        [SerializeField] private Transform _mapItemParent;
        [SerializeField] private ToggleGroup _toggleMapGroup;
        
        [HideInInspector] public MapType SelectedMapType;
        
        public Button StartGameButton => _startGameButton;
        public MapGuiItem MapItemTemplate => _mapItemTemplate;
        public Transform MapItemParent => _mapItemParent;
        public ToggleGroup ToggleMapGroup => _toggleMapGroup;
    }
}