using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Data
{
    [CreateAssetMenu(menuName = "Game/Data/SceneData", fileName = "NewSceneData", order = 99)]
    public class SceneData : ScriptableObject, IEnumTypeMark<ESceneType>
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField]public ESceneType Type { get; private set; }
    }
}