namespace HorrorGame
{
    public sealed class InitializeController
    {
        public InitializeController(MainController mainController, params FlyingCubeData[] flyingCubeData)
        {
            foreach (var cubeData in flyingCubeData)
            {
                new FlyingCubeInitializator(mainController, cubeData);
            }
        }
    }
}
