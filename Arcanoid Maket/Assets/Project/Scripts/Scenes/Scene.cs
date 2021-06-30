using System.Linq;
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
        private BaseController[] _controllers = null;

        public void Initialize()
        {
            InitializeStateMachine();
            InitializeController();
        }
        
        private void InitializeStateMachine()
        {
            _stateMachine.Initialize();
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