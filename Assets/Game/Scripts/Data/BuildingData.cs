using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(menuName = "Game/Data/BuildingData")]
    public class BuildingData : ScriptableObject, IEnumTypeMark<EBuildingType>
    {
        [field: SerializeField] 
        public EBuildingType Type { get; private set; }
    }
}