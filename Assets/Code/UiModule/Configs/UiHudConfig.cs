using Code.UiModule.Views;
using UnityEngine;

namespace Code.UiModule.Configs
{
    [CreateAssetMenu(fileName = "UiHudConfig", menuName = "Configs/UiModule/UiHudConfig")]
    public class UiHudConfig : ScriptableObject
    {
        [field: SerializeField] public GuiComponent[] Huds;
    }
}