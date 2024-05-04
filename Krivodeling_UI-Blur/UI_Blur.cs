using UnityEngine;
using UnityEngine.UI;

namespace _UI_
{
    internal class UI_Blur : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] float intensity = 0, multiplier = .2f;

        static readonly int
            _intensity = Shader.PropertyToID("_Intensity"),
            _multiplier = Shader.PropertyToID("_Multiplier");

        Material material;

        //----------------------------------------------------------------------------------------------------------

        private void Awake()
        {
            Graphic graphic = GetComponent<Graphic>();
            material = graphic.material = new(graphic.material);
        }

        //----------------------------------------------------------------------------------------------------------

        private void Update() => Refresh();

        [ContextMenu(nameof(Refresh))]
        public void Refresh()
        {
            material.SetFloat(_intensity, intensity);
            material.SetFloat(_multiplier, multiplier);
        }
    }
}