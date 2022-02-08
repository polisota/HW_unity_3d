using UnityEngine;


namespace HorrorGame
{
    [CreateAssetMenu(fileName = "CubeData", menuName = "Data")]
    public sealed class FlyingCubeData : ScriptableObject
    {
        public CubeStruct cubeStruct;
    }
}