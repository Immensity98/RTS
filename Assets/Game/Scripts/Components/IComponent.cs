using Game.Scripts.Enums;

namespace Game.Scripts.Components
{
    public interface IComponent
    {
        public object GetValue(EStat stat);
    }
}
