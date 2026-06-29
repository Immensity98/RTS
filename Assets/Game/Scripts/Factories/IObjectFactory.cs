using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Data;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Factories
{
    public interface IObjectFactory<T> where T : Object
    {
        public UniTask<T> CreateAsync(T data, CancellationToken cancellation = default);
    }
    
    public interface IObjectFactory<T, D>  where T : class where D : IData
    {
        public UniTask<T> CreateAsync(D data, ETeam team, CancellationToken cancellation = default);
    }
}
