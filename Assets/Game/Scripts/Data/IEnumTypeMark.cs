using System;

namespace Game.Scripts.Data
{
    public interface IEnumTypeMark<TEnum>
        where TEnum : struct, Enum
    {
        TEnum Type { get; }
    }
}