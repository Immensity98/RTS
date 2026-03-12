using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Components;
using Game.Scripts.Data;
using Game.Scripts.UnitsSystem;
using Object = UnityEngine.Object;

namespace Game.Scripts.Factories
{
    public class UnitFactory : IObjectFactory<UnitContainer, UnitData>
    {
        private ComponentFactory _componentFactory;

        public UnitFactory(ComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
        }

        public async UniTask<UnitContainer> CreateAsync(UnitData data, CancellationToken cancellation = default)
        {
            var model = new UnitModel(data);

            await UniTask.Yield(PlayerLoopTiming.Update);
            var view = Object.Instantiate(data.View);

            foreach (var kvp in model.Components)
            {
                var componentData = kvp.Value;
                var type = componentData.GetType();

                var component = (IComponent)Activator.CreateInstance(type);
                component.Init(data); 
            }

            return new UnitContainer(model, view);
        }
    }
}