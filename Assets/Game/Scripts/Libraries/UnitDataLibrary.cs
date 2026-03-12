using Game.Scripts.Data;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Libraries
{
    [CreateAssetMenu(menuName = "Game/Data/Libraries/UnitDataLibrary", fileName =  "UnitDataLibrary", order = 99)]
    public class UnitDataLibrary : DataLibrary<EUnitType, UnitData>
    {
        
    }
}