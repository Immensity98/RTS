using System.Collections.Generic;
using Game.Scripts.Enums;

namespace Game.Scripts.Components
{
    public interface IMovable 
    {
        public IReadOnlyDictionary<EStatValueType, float> Values { get; }
    }
}