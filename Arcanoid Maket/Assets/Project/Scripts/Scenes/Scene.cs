using Project.Scripts.GameStates.Abstract;
using Project.Scripts.MVC.Abstract;
using UnityEngine;

namespace Project.Scripts.Scenes
{
    public class Scene : MonoBehaviour
    {
        [SerializeField]
        private StateMachine _stateMachine = null;

        [SerializeField]
        private BaseController[] _controllers;

        public void Initialize()
        {
            InitializeStateMachine();
            InitializeController();
        }
        
        private void InitializeStateMachine()
        {
            _stateMachine.Initialize(this);
        }

        private void InitializeController()
        {
            foreach (var controller in _controllers)
            {
                controller.Initialize();
            }
        }
    }
}