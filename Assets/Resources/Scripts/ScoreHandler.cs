using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace SortCubes
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private GetterParameters[] _getters;
        public UnityEvent OnFull;
        public void Start()
        {
            if (_getters==null)
                return;
            foreach (var g in _getters)
            {
                g.getter.SetCount(g.targetCount);
                g.countText.text = "0";
                g.getter.OnCountChanged.AddListener(OnCountChanged);
            }

        }

        private void OnDestroy() 
        {
            foreach (var g in _getters)
            {
                g.getter.OnCountChanged.RemoveListener(OnCountChanged);
            }
        }

        private void OnCountChanged(Getter getter)
        {
            for (int i=0;i<_getters.Length;i++)
            {
                if (_getters[i].getter!=getter)
                    continue;
                _getters[i].currentCount++;
                _getters[i].countText.text = _getters[i].currentCount.ToString();
            }

            bool isFull = true;
            foreach (var g in _getters)
            {
                if (g.currentCount<g.targetCount)
                {
                    isFull = false;
                    break;
                }
            }

            if (isFull)
            {
                OnFull.Invoke();
            }

        }
    }

    [System.Serializable]
    public struct GetterParameters
    {
        public Getter getter;
        public int targetCount;
        public TMP_Text countText;
        [HideInInspector] public int currentCount;

    }
}
