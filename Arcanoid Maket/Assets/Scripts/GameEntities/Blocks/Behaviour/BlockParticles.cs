using Scripts.Utils.Extensions;
using UnityEngine;

namespace GameEntities.Blocks.Behaviour
{
    public class BlockParticles : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particles;

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