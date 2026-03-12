using System;
using Game.Scripts.Data;


namespace Game.Scripts.Components
{
    [Serializable]
    public class MovableComponent : IMovable, IComponent
    {
        public float MoveSpeed { get; private set; }

        public void Init(IData data)
        {
            throw new NotImplementedException();
        }
    }
}