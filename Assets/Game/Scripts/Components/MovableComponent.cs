using System;
using System.Collections.Generic;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.Scripts.Components
{
    [Serializable]
    public class MovableComponent : ComponentData, IMovable
    {
        public IReadOnlyDictionary<EStatValueType, float> Values => _values;
        [OdinSerialize] private Dictionary<EStatValueType, float> _values;

        public override void Init(IData data)
        {
            if (data != null)
            {
                _values = new();
                _values.Add(EStatValueType.Speed, data.GetValue(EStatValueType.Speed));
            }
            
            Debug.Log("Speed = " + Values[EStatValueType.Speed]);
        }
    }
}