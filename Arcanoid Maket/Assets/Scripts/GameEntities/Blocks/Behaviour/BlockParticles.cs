using System.Collections;
using Library.Extensions;
using UnityEngine;

namespace GameEntities.Blocks.Behaviour
{
    public class BlockParticles : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particles;

        public void SetParticleColor(Color color)
        {
            _particles.SetParticlesColor(color);
        }
        
        public IEnumerator PlayParticle()
        {
            _particles.Play();
            yield return new WaitWhile(() => _particles.isPlaying);
        }
    }
}