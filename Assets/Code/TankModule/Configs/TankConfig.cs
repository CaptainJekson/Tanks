using UnityEngine;

namespace Code.TankModule.Configs
{
    [CreateAssetMenu(fileName = "TankConfig", menuName = "Configs/TankModule/TankConfig")]
    public class TankConfig : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
    }
}