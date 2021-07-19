using BehaviorControllers.Abstract;
using UnityEngine.SceneManagement;

namespace BehaviorControllers.EntitiesControllers
{
    public class ScenesController : EntityController
    {
        public void LoadScene(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}