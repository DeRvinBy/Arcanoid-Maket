using MyLibrary.CollisionStorage.Colliders2D;

namespace GameEntities.Blocks.Components
{
    public class BlockCollider : CollisionCollider2D
    {
        public void EnableCollider()
        {
            _collider.enabled = true;
        }
        
        public void DisableCollider()
        {
            _collider.enabled = false;
        }
    }
}