using System;
using System.Collections.Generic;
using Game.Scripts.Enums;
using Sirenix.Serialization;

namespace Game.Scripts.Components
{
    [Serializable]
    public class ComponentData 
    {
        public IReadOnlyDictionary<EStat, float> StatValues => _statValues;
        [OdinSerialize] 
        protected Dictionary<EStat, float> _statValues;

        public float GetStatValue(EStat stat)
        {
            return _statValues != null && _statValues.TryGetValue(stat, out var value)
                ? value
                : 0f;
        }
    }
}
