using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using Game.Scripts.UnitsSystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Scripts.Factories
{
    public class UnitFactory : IObjectFactory<Unit, UnitData>
    {
        private ComponentFactory _componentFactory;

        public UnitFactory(ComponentFactory factory)
        {
            _componentFactory = factory;
        }

        public async UniTask<Unit> CreateAsync(UnitData data, ETeam team, CancellationToken cancellation = default)
        {
            var model = new UnitModel(data, team);
            var view = Object.Instantiate(data.View);

            if (view.TryGetComponent(out Unit unit))
            {
                InitializeComponents(model, data);
                unit.Initialize(model, view);

                return unit;
            }

            Debug.LogError($"[UnitFactory] Prefab '{view.name}' does not have Unit component!");
            return null;
        }
        
        private void InitializeComponents(UnitModel model, UnitData data)
        {
            if (data == null)
            {
                Debug.LogError("[UnitFactory] Data is null!]");
                return;
            }

            foreach (var component in data.Components)
            {
                if(component.Value == null)
                    continue;
                
                model.AddComponent(component.Key, _componentFactory.Create(component.Value));
            }
        }
    }
}