using System;
using System.Collections.Generic;
using Data.Libraries;
using Game.Scripts.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;

namespace Game.Scripts.Libraries
{
    public class DataLibrary<TEnum, T> : SerializedScriptableObject, IDataLibrary
        where TEnum : struct, Enum
        where T : ScriptableObject, IEnumTypeMark<TEnum>
    {
        [SerializeField] protected string _dataPath;
        [OdinSerialize] protected Dictionary<TEnum, T> _entities = new();

        public void Refresh()
        {
#if UNITY_EDITOR
            _entities.Clear();

            string typeName = typeof(T).Name;
            string[] guids = AssetDatabase.FindAssets($"t:{typeName}", new[] { _dataPath });

            foreach (string guid in guids)
            {
                var data = AssetDatabase.LoadAssetAtPath<T>(
                    AssetDatabase.GUIDToAssetPath(guid));

                if (!_entities.ContainsKey(data.Type))
                    _entities[data.Type] = data;
            }

            AssetDatabase.SaveAssets();
#endif
        }

        public T GetEntity(TEnum entity)
        {
            if (!_entities.ContainsKey(entity) || _entities[entity] == null)
            {
                Debug.LogError($"[DataLibrary] Key {entity} not exists!");
                return null;
            }
            
            return _entities[entity];
        }
        
    }
}