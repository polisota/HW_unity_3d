using UnityEngine;
using System.Collections.Generic;


namespace HorrorGame
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private FlyingCubeData _flyingCubeDataOne;
        [SerializeField] private FlyingCubeData _flyingCubeDataTwo;

        private List<IUpdatable> _iIpdatables = new List<IUpdatable>();

        private void Start()
        {
            new InitializeController(this, _flyingCubeDataOne, _flyingCubeDataTwo);
        }
        
        private void Update()
        {
            for (int i = 0; i < _iIpdatables.Count; i++)
            {
                _iIpdatables[i].UpdateTick();
            }
        }

        public void AddUpdatable(IUpdatable iUpdatable)
        {
            _iIpdatables.Add(iUpdatable);
        }
    }
}
