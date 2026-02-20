using System;
using System.Threading;
using Game.Scripts.Enums;
using Game.Scripts.System.Logger;
using UnityEngine;
using VContainer.Unity;

namespace Game.Scripts.System
{
    public class Bootstrapper : IAsyncStartable, IDisposable, IInitializable
    {
        private CancellationTokenSource _cts;
        private SceneLoader _sceneLoader;

        public Bootstrapper(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public async Awaitable StartAsync(CancellationToken cancellation = default)
        {
            _cts = new CancellationTokenSource();
            
            try
            {
                await _sceneLoader.SceneLoadAsync(ESceneType.Test, _cts.Token);
            }
            catch (Exception ex)
            {
                GameLogger.Log(ELogChannel.System, $"[Bootstrapper] Scene loading failed: {ex}");
            }
        }
        
        public void Dispose()
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }
        
        public void Initialize()
        {
            
        }
    }
}