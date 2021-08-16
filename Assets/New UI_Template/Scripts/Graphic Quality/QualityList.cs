using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace LevelManagement.Quality
{
    [CreateAssetMenu(fileName = "QualityList", menuName = "Selectors/Quality/Create QualityList", order = 1)]
    public class QualityList : ScriptableObject
    {
        [SerializeField] List<RenderPipelineAsset> qualities;

        public int QualityCount => qualities.Count;

        public RenderPipelineAsset GetQuality(int index)
        {
            return qualities[index];
        }
    }
}