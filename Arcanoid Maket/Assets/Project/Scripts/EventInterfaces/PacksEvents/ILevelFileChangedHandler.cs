using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.EventInterfaces.PacksEvents
{
    public interface ILevelFileChangedHandler : IGlobalSubscriber
    {
        void OnLevelFileChanged(TextAsset levelFile);
    }
}