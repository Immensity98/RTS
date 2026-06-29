using Game.Scripts.Components;
using Game.Scripts.Enums;

namespace Game.Scripts.Factories
{
    public interface IComponentFactory
    {
        public Component Create(ComponentData data);
    }
}