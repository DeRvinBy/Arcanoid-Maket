using Project.Scripts.Architecture.Abstract;
using Project.Scripts.Packs.Data;
using Project.Scripts.Packs.Data.Game;
using UnityEngine;

namespace Project.Scripts.Packs
{
    public class PacksController : SceneEntitiesController
    {
        [SerializeField]
        private GamePacks _gamePacks;

        public override void Initialize()
        {
            
        }
    }
}