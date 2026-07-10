using System;
using System.Collections.Generic;
using Game.Scripts.Components;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.Scripts.UnitsSystem
{
    [Serializable]
    public class UnitModel
    {
        public string ID; //{ get; private set; }
        public ETeam Team; //{ get; private set; }
        public Vector3 Position; //{ get; private set; }
        public bool IsSelectable; //  { get; private set; }
        
        [ShowInInspector]
        [OdinSerialize] 
        public IReadOnlyDictionary<EComponentType, IComponent> Components => _components;
        private Dictionary<EComponentType, IComponent> _components;

        private UnitData _data;

        public UnitModel(UnitData data, ETeam team)
        {
            _data = data;
            Team = team;

            Initialize();
        }

        private void Initialize()
        {
            ID = _data.ID;
            
            if (Team == ETeam.Player)
                IsSelectable = true;

            _components = new();
        }
        

        public void AddComponent(EComponentType type, IComponent component)
        {
            if (!_components.ContainsKey(type) && component != null)
            {
                _components.Add(type, component);
            }
        }

        public IComponent GetComponent(EComponentType type)
        {
            Components.TryGetValue(type, out IComponent component);
            return component;
        }

        private void LoadState()
        {
        }
    }
}