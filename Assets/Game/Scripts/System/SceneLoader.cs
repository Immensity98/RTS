using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enums;
using Game.Scripts.Libraries;
using Game.Scripts.System.Logger;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.System
{
    public class SceneLoader
    {
        private SceneDataLibrary _sceneDataLibrary;

        public SceneLoader(SceneDataLibrary sceneDataLibrary)
        {
            _sceneDataLibrary = sceneDataLibrary;
        }

        public async UniTask SceneLoadAsync(ESceneType sceneType, CancellationToken cts)
        {
            var sceneData = _sceneDataLibrary.GetData(sceneType);

            try
            {
                await SceneManager.LoadSceneAsync(sceneData.Name).WithCancellation(cts);

                GameLogger.Log(ELogChannel.System, $"[SceneLoader] Scene <color=green>" +
                                                   $"{sceneData.Name}</color> has been loaded!");
            }
            catch (OperationCanceledException)
            {
                Debug.LogError($"Scene loading {sceneData.Name} was canceled.");
            }
        }
    }
}
