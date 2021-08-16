using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Utilities
{
    public abstract class Selector<T, J> : MonoBehaviour where T : ScriptableObject where J : class
    {
        #region INSPECTOR
        [SerializeField] protected T _list;
        #endregion

        #region PROTECTED
        protected int _currentIndex = 0;
        #endregion

        #region PROPERTIES
        protected int CurrentIndex => _currentIndex;
        #endregion

        protected abstract void ClampIndex();
        public abstract J GetItem(int index);

        public abstract J GetCurrentItem();

        void SetIndex (int index)
        {
            _currentIndex = index;
            ClampIndex();
        }

        public void IncrementIndex()
        {
            SetIndex(_currentIndex + 1);
        }

        public void DecrementIndex()
        {
            SetIndex(_currentIndex - 1);
        }
    }

}