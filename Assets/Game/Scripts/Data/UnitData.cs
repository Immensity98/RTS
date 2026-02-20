using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(menuName = "Game/Data/UnitData", fileName = "NewUnitData", order = 99)]
    public class UnitData : ScriptableObject, IEnumTypeMark<EUnitType>
    {
       [field: SerializeField]  
       public EUnitType Type { get;  private set; }
    }
}