using Game.Scripts.Data;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Libraries
{
    [CreateAssetMenu(menuName = "Game/Data/Libraries/BuildingDataLibrary", 
        fileName = "BuildingDataLibrary", order = 99)]
    public class BuildingDataLibrary : DataLibrary<EBuildingType, BuildingData>
    {
        
    }
}