using UnityEditor.UIElements;
using UnityEngine;

namespace Code.TankModule.Configs
{
    [CreateAssetMenu(fileName = "EngineConfig", menuName = "Configs/TankModule/EngineConfig")]
    public class EngineConfig : ScriptableObject
    {
        [SerializeField] private Sprite _icon;

        public Sprite Icon => _icon;
    }
}