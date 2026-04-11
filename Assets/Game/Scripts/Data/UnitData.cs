using System.Collections.Generic;
using Game.Scripts.Components;
using Game.Scripts.Enums;
using Game.Scripts.UnitsSystem;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(menuName = "Game/Data/UnitData", fileName = "NewUnitData", order = 99)]
    public class UnitData : SerializedScriptableObject, IEnumTypeMark<EUnitType>, IData
    {
        public IReadOnlyDictionary<EStatValueType, float> Values => _values;
        [OdinSerialize] private Dictionary<EStatValueType, float> _values;
        
        public IReadOnlyDictionary<EComponentType, ComponentData> Components => _components;
        [OdinSerialize] private Dictionary<EComponentType, ComponentData> _components;
        
        [field: SerializeField] public UnitView View { get; private set; }
  
        [field: SerializeField] public EFraction Fraction { get; private set; }
        [field: SerializeField] public EUnitType Type { get; private set; }
        [field: SerializeField] public string ID { get; private set; }
    }
}