using Project.Scripts.BehaviorControllers.Abstract;
using UnityEngine.SceneManagement;

namespace Project.Scripts.GameEntities
{
    public class ScenesController : EntityController
    {
        public void LoadScene(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}