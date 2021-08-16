using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;
using LevelManagement.Quality;

namespace LevelManagement
{
    public class GraphicQualitySettings : MonoBehaviour
    {
        [SerializeField] Text qualityText;
        QualitySelector qualitySelector;
        RenderPipelineAsset currentQuality;

        private void Awake()
        {
            qualitySelector = this.GetComponent<QualitySelector>();
            UpdateInfo();
        }
        public void UpdateInfo()
        {
            currentQuality = qualitySelector.GetCurrentItem();
            qualityText.text = currentQuality.name;
            QualitySettings.renderPipeline = currentQuality;
        }
        public void OnNextPressed()
        {
            qualitySelector.IncrementIndex();
            UpdateInfo();
        }

        public void OnPreviousPressed()
        {
            qualitySelector.DecrementIndex();
            UpdateInfo();
        }
    }
}