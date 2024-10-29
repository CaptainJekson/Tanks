using UnityEditor.UIElements;
using UnityEngine;

namespace Code.TankModule.Configs
{
    [CreateAssetMenu(fileName = "EngineConfig", menuName = "Configs/TankModule/EngineConfig")]
    public class EngineConfig : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _maxReverseSpeed;
        [SerializeField] private float _power;
        
        public Sprite Icon => _icon;
        public float MaxSpeed => _maxSpeed;
        public float MaxReverseSpeed => _maxReverseSpeed;
        public float Power => _power;
    }
}