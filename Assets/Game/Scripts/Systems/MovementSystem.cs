using Game.Scripts.Enums;
using Game.Scripts.System.Logger;

namespace Game.Scripts.Systems
{
    public class MovementSystem : ISystem
    {
        public void Execute()
        {
            GameLogger.Log(ELogChannel.System, "[MovementSystem] MovementSystem is working");
        }
    }
}