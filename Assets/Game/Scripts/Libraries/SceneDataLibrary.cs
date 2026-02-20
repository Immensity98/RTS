using System.Collections.Generic;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Libraries
{
    [CreateAssetMenu(menuName = "Game/Data/Libraries/SceneDataLibrary", fileName =  "SceneDataLibrary", order = 99)]
    public class SceneDataLibrary : DataLibrary<ESceneType, SceneData>
    {
        public SceneData GetData(ESceneType sceneType)
        {
            _entities.TryGetValue(sceneType, out var sceneData);
            return sceneData;
        }
    }
}