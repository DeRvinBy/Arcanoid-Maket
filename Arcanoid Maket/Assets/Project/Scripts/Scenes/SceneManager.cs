using UnityEngine;

namespace Project.Scripts.Scenes
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField]
        private Scene _currentScene = null;

        private void Start()
        {
            StartCurrentScene();
        }

        private void StartCurrentScene()
        {
            _currentScene.Initialize();
        }
    }
}