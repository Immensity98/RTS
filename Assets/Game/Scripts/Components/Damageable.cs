using System;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using Game.Scripts.System.Logger;

namespace Game.Scripts.Components
{
    [Serializable]
    public class Damageable : ComponentData
    {
        public float Damage { get; private set; }
        
        public void Init(UnitData data)
        {
            Damage = data.Damage;
            GameLogger.Log(ELogChannel.System, "Damage = " + Damage);
        }
    }
}