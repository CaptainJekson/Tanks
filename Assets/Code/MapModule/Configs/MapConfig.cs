using Code.GlobalUtils;
using UnityEditor;
using UnityEngine;

namespace Code.MapModule.Configs
{
    [CreateAssetMenu(fileName = "MapConfig", menuName = "Configs/MapModule/MapConfig")]
    public class MapConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private SceneAsset _scene;
        [SerializeField] private PlacementPoint _playerSpawnPoint;

        public string Name => _name;
        public Sprite Icon => _icon;
        public SceneAsset Scene => _scene;
        public PlacementPoint PlayerSpawnPoint => _playerSpawnPoint;
    }
}