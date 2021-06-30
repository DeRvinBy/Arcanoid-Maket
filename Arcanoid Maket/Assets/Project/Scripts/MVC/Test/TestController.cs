using Project.Scripts.MVC.Abstract;
using Project.Scripts.MVC.Test.Interfaces;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.MVC.Test
{
    public class TestController : BaseController
    {
        [SerializeField]
        private TestView _testView = null;

        private TestModel _model;
        
        public override void Initialize()
        {
            _model = new TestModel();
            _model.Initialize();
            _model.OnLivesChanged += LivesChanged;
            _model.OnLivesChanged += _testView.PrintCurrentLives;
            
            _testView.Initialize();
            _testView.OnDamaged += OnDamaged;
            _testView.OnHealth += OnHealth;
            
            Debug.Log("Controller initialized");
        }

        private void OnHealth(int obj)
        {
            _model.AddLives(obj);
        }
        
        private void OnDamaged(int obj)
        {
            _model.RemoveLives(obj);
        }

        private void LivesChanged(int count)
        {
            if (count < 0)
            {
                EventBus.RaiseEvent<IGameEndedEvent>(a => a.EndGame());
            }
        }
    }
}