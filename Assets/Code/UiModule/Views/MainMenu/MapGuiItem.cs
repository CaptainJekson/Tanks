using Code.MapModule.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UiModule.Views.MainMenu
{
    public class MapGuiItem : MonoInstaller
    {
        [SerializeField] public Toggle Toggle;
        [SerializeField] public Image MainImage;
        [SerializeField] public TextMeshProUGUI Name;

        [HideInInspector] public MapType MapType;
    }
}