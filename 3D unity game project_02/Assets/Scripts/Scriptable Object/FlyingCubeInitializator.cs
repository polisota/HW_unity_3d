using UnityEngine;


namespace HorrorGame
{
    public sealed class FlyingCubeInitializator
    {
        public FlyingCubeInitializator(MainController mainController, FlyingCubeData flyingCubeData)
        {
            var spawnedCube = Object.Instantiate(flyingCubeData.cubeStruct.Cube,
                flyingCubeData.cubeStruct.StartPosition,
                Quaternion.identity);

            var cubeStruct = flyingCubeData.cubeStruct;
            cubeStruct.Cube = spawnedCube;

            var cubeModel = new FlyingCubeModel(cubeStruct);
            mainController.AddUpdatable(new FlyingCubeController(cubeModel));
        }
    }
}
