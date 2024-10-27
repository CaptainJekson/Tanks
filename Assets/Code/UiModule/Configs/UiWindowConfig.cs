using Code.UiModule.Views;
using UnityEngine;

namespace Code.UiModule.Configs
{
    [CreateAssetMenu(fileName = "UiWindowConfig", menuName = "Configs/UiModule/UiWindowConfig")]
    public class UiWindowConfig : ScriptableObject
    {
        [field: SerializeField] public GuiComponent[] Windows;
    }
}