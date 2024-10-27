using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.GlobalUtils
{
    [Serializable]
    public class PlacementPoint
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private Vector3 _rotation;

        public Vector3 Position => _position;
        public Quaternion Rotation => Quaternion.Euler(_rotation);
    }
}