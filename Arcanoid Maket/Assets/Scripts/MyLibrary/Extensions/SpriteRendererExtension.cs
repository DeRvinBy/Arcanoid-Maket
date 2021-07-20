using UnityEngine;

namespace MyLibrary.Extensions
{
    public static class SpriteRendererExtension
    {
        public static void SetTransformScaleOneByBoundsSize(this SpriteRenderer spriteComp)
        {
            var scale = Vector3.one;
            var boundSize = spriteComp.sprite.bounds.size;
            var newScale = new Vector3(scale.x / boundSize.x, scale.y / boundSize.y, scale.z);
            spriteComp.transform.localScale = newScale;
        }
    }
}