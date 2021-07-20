using DG.Tweening;
using UnityEngine;

namespace MyLibrary.UI.Button.Abstract
{
    public abstract class AbstractButtonAnimation : MonoBehaviour
    {
        public abstract void SetupAnimation();
        public abstract void PlayAnimation(TweenCallback callback);
    }
}