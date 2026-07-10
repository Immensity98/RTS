using System.Collections.Generic;
using Game.Scripts.Enums;
using Sirenix.Serialization;

namespace Game.Scripts.Components
{
    public class Component : IComponent
    {
        public IReadOnlyDictionary<EStat, float> StatValues => _statValues;
        [OdinSerialize] protected Dictionary<EStat, float> _statValues;

        public void Init(ComponentData data)
        {
            _statValues = new Dictionary<EStat, float>();

            foreach (var stat in data.StatValues)
            {
                _statValues[stat.Key] = stat.Value;
            }
        }

        public object GetValue(EStat stat)
        {
            return _statValues != null && _statValues.TryGetValue(stat, out var value)
                ? value : 0f;
        }
    }
}