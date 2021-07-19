using System.Collections.Generic;
using Scripts.GamePacks.Data.Packs;
using Scripts.UI.Packs.PackItem;
using Scripts.Utils.ObjectPool;
using UnityEngine;

namespace Scripts.UI.Packs
{
    public class UIPacksManager : MonoBehaviour
    {
        private Dictionary<string, PackContainerEntity> _packContainersMap;

        public void UpdatePackContainers(Dictionary<string, PackInfo> packsInfo)
        {
            if (_packContainersMap == null)
            {
                CreatePackContainersMap(packsInfo);
            }

            foreach (var packKey in packsInfo.Keys)
            {
                if (packsInfo[packKey].IsOpen)
                {
                    _packContainersMap[packKey].SetupPackContainer(packsInfo[packKey]);
                }
                else
                {
                    _packContainersMap[packKey].SetupDefaultContainer(packsInfo[packKey]);
                }
            }
        }

        private void CreatePackContainersMap(Dictionary<string, PackInfo> packsInfo)
        {
            _packContainersMap = new Dictionary<string, PackContainerEntity>();
            foreach (var packKey in packsInfo.Keys)
            {
                var packContainer = PoolsManager.Instance.GetObject<PackContainerEntity>(Vector3.zero, transform);
                packContainer.transform.localScale = Vector3.one;
                _packContainersMap.Add(packKey, packContainer);
            }
        }
    }
}