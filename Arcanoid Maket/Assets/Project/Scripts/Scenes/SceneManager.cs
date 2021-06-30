using UnityEngine;

namespace Project.Scripts.Scenes
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField]
        private Scene _currentScene = null;

        private void Awake()
        {
            CreateCurrentScene();
        }

        private void CreateCurrentScene()
        {
            _currentScene.Initialize();
        }
    }
}