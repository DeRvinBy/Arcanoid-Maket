using UnityEngine;

namespace MyLibrary.Extensions
{
    public static class MonoBehaviourExtension
    {
        public static void SetActive(this MonoBehaviour mono, bool isActive)
        {
            mono.transform.gameObject.SetActive(isActive);
        }
    }
}