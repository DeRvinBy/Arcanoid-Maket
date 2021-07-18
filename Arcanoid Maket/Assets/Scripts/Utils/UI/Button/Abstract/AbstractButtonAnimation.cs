using DG.Tweening;
using UnityEngine;

namespace Scripts.Utils.UI.Button.Abstract
{
    public abstract class AbstractButtonAnimation : MonoBehaviour
    {
        public abstract void SetupAnimation();
        public abstract void PlayAnimation(TweenCallback callback);
    }
}