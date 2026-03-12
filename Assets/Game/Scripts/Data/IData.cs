using System.Collections.Generic;
using Game.Scripts.Enums;

namespace Game.Scripts.Data
{
    public interface IData
    {
        public IReadOnlyDictionary<EStatValueType, float> Values { get; }

        public float GetValue(EStatValueType type)
        { 
            Values.TryGetValue(type, out var value);
            return value;
        }
    }
}