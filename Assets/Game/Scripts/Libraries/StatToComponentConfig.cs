using System.Collections.Generic;
using Game.Scripts.Enums;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.Scripts.Libraries
{
    [CreateAssetMenu(menuName = "Game/StatToComponentConfig", fileName = "StatToComponentConfig")]
    public class StatToComponentConfig : SerializedScriptableObject
    {
        [ShowInInspector]
        [OdinSerialize]
        private Dictionary<EStat, EComponentType> _components;

        public EComponentType GetComponentType(EStat stat)
        {
            if (!_components.ContainsKey(stat))
            {
                Debug.LogError($"[StatToComponentConfig] Stat {stat} not found!");
                return default;
            }

            return _components[stat];
        }
    }
}