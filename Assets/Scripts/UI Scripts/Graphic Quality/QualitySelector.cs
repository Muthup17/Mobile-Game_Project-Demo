using System.Collections;
using UnityEngine.Rendering;
using UnityEngine;
using LevelManagement.Utilities;

namespace LevelManagement.Quality
{
    public class QualitySelector : Selector<QualityList, RenderPipelineAsset>
    {
        public override RenderPipelineAsset GetCurrentItem()
        {
            return _list.GetQuality(CurrentIndex);
        }

        public override RenderPipelineAsset GetItem(int index)
        {
            return _list.GetQuality(index);
        }

        protected override void ClampIndex()
        {
            if (_list.QualityCount == 0)
            {
                Debug.LogWarning("MISSION SELECTOR ClampIndex: missing mission setup!");
                return;
            }

            if (_currentIndex >= _list.QualityCount)
            {
                _currentIndex = 0;
            }

            if (_currentIndex < 0)
            {
                _currentIndex = _list.QualityCount - 1;
            }
        }
    }
}