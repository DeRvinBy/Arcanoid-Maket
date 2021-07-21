using UnityEngine;

namespace MyLibrary.CollisionStorage.Extensions
{
    public static class StoredCollider2D
    {
        public static bool IsColliderHasMonoBehaviour<T>(this Collider2D monoCollider) where T : MonoBehaviour
        {
            return CollisionStorage2D.Instance.IsColliderHasMonoBehaviour<T>(monoCollider);
        }
        
        public static T GetColliderMonoBehaviour<T>(this Collider2D monoCollider) where T : MonoBehaviour
        {
            return CollisionStorage2D.Instance.GetColliderMonoBehaviour<T>(monoCollider);
        }
    }
}