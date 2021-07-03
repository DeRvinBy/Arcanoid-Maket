using Project.Scripts.Utils.Extensions;
using UnityEngine;

namespace Project.Scripts.MVC.Blocks.GameComponents
{
    public class BlockParticles : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particles = null;

        public bool IsParticlesPlaying => _particles.isPlaying;
        
        public void SetParticleColor(Color color)
        {
            _particles.SetParticlesColor(color);
        }
        
        public void PlayParticle()
        {
            _particles.Play();
        }
    }
}