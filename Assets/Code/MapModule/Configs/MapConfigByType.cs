using System;
using Code.MapModule.Enums;
using UnityEngine;

namespace Code.MapModule.Configs
{
    [Serializable]
    public class MapConfigByType
    {
        [SerializeField] private MapType _mapType;
        [SerializeField] private MapConfig _mapConfig;

        public MapType MapType => _mapType;
        public MapConfig MapConfig => _mapConfig;
    }
}