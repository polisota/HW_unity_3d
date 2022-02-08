using UnityEngine;
using System;


namespace HorrorGame
{
    [Serializable]
    public struct CubeStruct
    {
        public GameObject Cube;
        public float CubeSpeed;
        public float CubeLifeTime;
        public Vector3 StartPosition;
    }
}
