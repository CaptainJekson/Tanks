using System.Collections.Generic;
using Code.MapModule.Enums;
using UnityEngine;

namespace Code.MapModule.Configs
{
    [CreateAssetMenu(fileName = "MapsCollectionConfig", menuName = "Configs/MapModule/MapsCollectionConfig")]
    public class MapsCollectionConfig : ScriptableObject
    {
        [SerializeField] private List<MapConfigByType> _mapConfigsByType;
        
        public List<MapConfigByType> MapConfigsByType => _mapConfigsByType;

        public bool TryGetMapConfigByType(MapType type, out MapConfig mapConfig)
        {
            mapConfig = null;
            
            foreach (var mapConfigByType in _mapConfigsByType)
            {
                if (mapConfigByType.MapType != type)
                {
                    continue;
                }

                mapConfig = mapConfigByType.MapConfig;
                return true;
            }

            return false;
        }
    }
}