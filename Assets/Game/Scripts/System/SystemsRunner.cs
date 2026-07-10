using System.Collections.Generic;
using Game.Scripts.Enums;
using Game.Scripts.System.Logger;
using Game.Scripts.Systems;
using VContainer.Unity;

namespace Game.Scripts.System
{
    public class SystemsRunner : ITickable
    {
        private IEnumerable<ISystem> _systems;

        public SystemsRunner(IEnumerable<ISystem> systems)
        {
            GameLogger.Log(ELogChannel.System, "[SystemsRunner] SystemsRunner initialized");

            _systems = systems;
        }

        public void Tick()
        {
            if (_systems == null)
            {
                GameLogger.Log(ELogChannel.Error, "[SystemsRunner] Systems collection is null!");
                return;
            }
            
            foreach (var system in _systems)
            {
                system.Execute();
            }
        }
    }
}