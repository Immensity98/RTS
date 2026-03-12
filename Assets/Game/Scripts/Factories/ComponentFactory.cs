using System;
using Game.Scripts.Components;

namespace Game.Scripts.Factories
{
    public class ComponentFactory : IComponentFactory
    {
        public T Create<T>() where T : IComponent
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
