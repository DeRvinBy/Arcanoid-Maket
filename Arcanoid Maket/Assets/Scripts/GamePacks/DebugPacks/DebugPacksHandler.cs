using GamePacks.Data;
using GamePacks.Data.Config;
using UnityEngine;

namespace GamePacks.DebugPacks
{
    public class DebugPacksHandler : MonoBehaviour
    {
        private PacksService _service;
        
        public void Initialize(PacksConfig config, PacksService service, bool isSaveExist)
        {
            _service = service;
            
            if (isSaveExist)
            {
                _service.StartDebugPack(config.DebugPack, config.DebugLevelId);
            }  
        }
        
        [ContextMenu("Complete all packs")]
        public void CompleteAllPacks()
        {
            _service.CompleteAllPacks();
        }
    }
}