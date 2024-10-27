using Code.UiModule.Views;
using UnityEngine;

namespace Code.UiModule.Configs
{
    [CreateAssetMenu(fileName = "UiPopupConfig", menuName = "Configs/UiModule/UiPopupConfig")]
    public class UiPopupConfig : ScriptableObject
    {
        [field: SerializeField] public GuiComponent[] Popups;
    }
}