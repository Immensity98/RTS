using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Data;
using Game.Scripts.UnitsSystem;
using UnityEngine;

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
            
            return new UnitContainer(model, view);
        }
    }
}