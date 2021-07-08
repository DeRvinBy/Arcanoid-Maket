using UnityEngine;

namespace Project.Scripts.Architecture.Scenes
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField]
        private Scene _currentScene;

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