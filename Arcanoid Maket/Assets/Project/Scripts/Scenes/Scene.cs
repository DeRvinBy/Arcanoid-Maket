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
            InitializeController();
            InitializeStateMachine();
        }
        
        private void InitializeController()
        {
            foreach (var controller in _controllers)
            {
                controller.Initialize();
            }
        }
        
        private void InitializeStateMachine()
        {
            _stateMachine.Initialize();
        }
    }
}