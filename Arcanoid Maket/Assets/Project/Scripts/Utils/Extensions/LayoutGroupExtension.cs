using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Utils.Extensions
{
    public static class LayoutGroupExtension
    {
        public static void UpdateByElementsCount(this LayoutGroup group, int elementsCount)
        {
            var rectTransform = (RectTransform) group.transform;
            
        }
    }
}