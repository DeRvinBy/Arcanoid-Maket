using System.Linq;
using Project.Scripts.GameStates.Abstract;
using Project.Scripts.MVC.Abstract;
using UnityEngine;

namespace Project.Scripts.Scenes
{
    public class Scene : MonoBehaviour
    {
        [SerializeField]
        private StateMachine _stateMachine;

        [SerializeField]
        private SceneEntitiesController[] _controllers;

        public void Initialize()
        {
            InitializeControllers();
            InitializeStateMachine();
        }
        
        private void InitializeControllers()
        {
            foreach (var controller in _controllers)
            {
                controller.Initialize();
            }
        }
        
        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(this);
        }

        public T GetController<T>() where T : SceneEntitiesController
        {
            return (T) _controllers.First(c => c is T);
        }
    }
}