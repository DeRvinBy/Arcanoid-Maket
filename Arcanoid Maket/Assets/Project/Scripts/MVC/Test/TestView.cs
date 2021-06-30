using System;
using Project.Scripts.MVC.Abstract;
using UnityEngine;

namespace Project.Scripts.MVC.Test
{
    public class TestView : BaseView
    {
        public Action<int> OnDamaged;
        public Action<int> OnHealth;
        
        public override void Initialize()
        {
            Debug.Log("View initialized");
        }

        public void Update()
        {
            if(Input.GetKey(KeyCode.D))
                OnDamaged?.Invoke(2);
            
            if(Input.GetKey(KeyCode.H))
                OnHealth?.Invoke(5);
        }

        public void PrintCurrentLives(int livesCount)
        {
            Debug.Log("Current lives: " + livesCount);
        }
    }
}