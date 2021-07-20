using UnityEngine;

namespace MyLibrary.Extensions
{
    public static class ParticlesExtension
    {
        public static void SetParticlesColor(this ParticleSystem particles, Color color)
        {
            var particleSettings = particles.main;
            particleSettings.startColor = color;
        }
    }
}