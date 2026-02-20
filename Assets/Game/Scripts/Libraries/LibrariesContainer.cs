#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using Data.Libraries;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Libraries
{
    public class LibrariesContainer : SerializedScriptableObject
    {
        [SerializeField] private List<ScriptableObject> _libraries;

        public List<IDataLibrary> GetLibraries()
        {
            if (_libraries != null)
            {
                List<IDataLibrary> libraries = new();

                foreach (var library in _libraries)
                {
                    libraries.Add((IDataLibrary)library);
                }
            
                return libraries;
            }
        
        
            throw new Exception("[LibrariesContainer]: Libraries container is null!]");
        }
    
        public T GetLibrary<T>() where T : ScriptableObject, IDataLibrary
        {
            if (_libraries == null)
                throw new Exception("[LibrariesContainer]: Libraries container is null!]");

            return _libraries.FirstOrDefault(library => library is T) as T;
        }

        public void AddLibrary(ScriptableObject library)
        {
            if (_libraries == null)
                _libraries = new();
        
            if(library is IDataLibrary && !_libraries.Contains(library))
                _libraries.Add(library);
        }

        public void ClearLibraries()
        {
            if (_libraries != null)
                _libraries.Clear();
        }
    }
}
#endif