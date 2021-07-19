using Scripts.BehaviorControllers.Abstract;
using UnityEngine.SceneManagement;

namespace Scripts.BehaviorControllers.EntitiesControllers
{
    public class ScenesController : EntityController
    {
        public void LoadScene(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}