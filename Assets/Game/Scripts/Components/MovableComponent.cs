using System;
using System.Collections.Generic;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Components
{
    [Serializable]
    public class MovableComponent : Component
    {
        private Dictionary<EStat, float> _statValues;

        public object GetValue(EStat stat)
        {
            throw new NotImplementedException();
        }

        public void SetValue(EStat stat, float value)
        {
            Debug.Log(_statValues);
        }
    }
}