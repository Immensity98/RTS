using System;
using System.Collections.Generic;
using Game.Scripts.Components;
using Game.Scripts.Data;
using Game.Scripts.Enums;

namespace Game.Scripts.UnitsSystem
{
    [Serializable]
    public class UnitModel
    {
        public string ID; 
        
        public IReadOnlyDictionary<EComponentType, ComponentData> Components => _components;
        private Dictionary<EComponentType, ComponentData> _components;

        private UnitData _data;

        public UnitModel(UnitData data)
        {
            _data = data;

            Initialize();
        }

        public void AddComponent(EComponentType type, ComponentData componentData)
        {
            if (!_components.ContainsKey(type) && componentData != null)
            {
                _components.Add(type, componentData);
            }
        }

      

        private void Initialize()
        {
           InitializeComponents();
           ID = _data.ID;
        }

        private void InitializeComponents()
        {
            _components = new Dictionary<EComponentType, ComponentData>();

            foreach (var pair in _data.Components)
            {
                var component = pair.Value;

                if (_components == null || _data == null || component == null || _components.ContainsKey(pair.Key))
                {
                    continue;
                }

                var type = component.GetType();
                var concreteComponent = (ComponentData)Activator.CreateInstance(type); // возможно неоптимальное решение (активатор)

                //concreteComponent.Init(_data);
                _components.Add(pair.Key, concreteComponent);
            }
        }

        private void LoadState()
        {
        }
    }
}