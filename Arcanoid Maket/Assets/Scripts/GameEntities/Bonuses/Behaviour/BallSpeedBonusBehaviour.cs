using GameEntities.Bonuses.Interfaces;
using UnityEngine;

namespace GameEntities.Bonuses.Behaviour
{
    public class BallSpeedBonusBehaviour : IBonusBehaviour
    {
        public float VariableSpeed { get; private set; }

        public BallSpeedBonusBehaviour(float speed, float time)
        {
            
        }
        
        public void Action()
        {
            Debug.Log("action");
        }
    }
}