using UnityEngine;

namespace Animations.Configs
{
    [CreateAssetMenu(fileName = "New Brightness Animation Config", menuName = "Animations Config/Brightness Animation Config")]
    public class BrightnessAnimationConfig : ScriptableObject
    {
        [SerializeField]
        private float _deltaBrightness;

        public Color GetStartColor(Color color)
        {
            Color.RGBToHSV(color, out var H, out var S, out var V);
            var result = Color.HSVToRGB(H, S, V);
            result.a = color.a;
            return result;
        }

        public Color GetTargetColor(Color color)
        {
            Color.RGBToHSV(color, out var H, out var S, out var V);
            var result = Color.HSVToRGB(H, S, V - _deltaBrightness);
            result.a = color.a;
            return result;
        }
    }
}