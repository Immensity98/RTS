using Game.Scripts.Components;

namespace Game.Scripts.Factories
{
    public interface IComponentFactory
    {
        public T Create<T>() where T : IComponent;
    }
}