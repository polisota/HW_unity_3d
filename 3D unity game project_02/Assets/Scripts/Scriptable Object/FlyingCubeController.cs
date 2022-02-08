using UnityEngine;


namespace HorrorGame
{
    public sealed class FlyingCubeController : IUpdatable
    {
        private FlyingCubeModel _flyingCubeModel;

        public FlyingCubeController(FlyingCubeModel flyingCubeModel)
        {
            _flyingCubeModel = flyingCubeModel;
        }

        public void UpdateTick()
        {            
            _flyingCubeModel._cubeStruct.Cube.transform.position +=
                _flyingCubeModel._cubeStruct.Cube.transform.forward * 
                _flyingCubeModel._cubeStruct.CubeSpeed * Time.deltaTime;
        }
    }
}
