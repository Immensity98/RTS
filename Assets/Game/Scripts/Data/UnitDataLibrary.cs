using Game.Scripts.Enums;
using Game.Scripts.Libraries;
using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(menuName = "Game/Data/Libraries/UnitDataLibrary", fileName =  "UnitDataLibrary", order = 99)]
    public class UnitDataLibrary : DataLibrary<EUnitType, UnitData>
    {
        
    }
}