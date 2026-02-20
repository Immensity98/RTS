using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.System.Logger
{
    public static class GameLogger
    {
        public static void Log(ELogChannel channel, string message)
        {
            switch (channel)
            {
                case ELogChannel.System:
                    Debug.Log($"[System] {message}");
                    break;
                case ELogChannel.UI:
                    Debug.Log($"[UI] {message}");
                    break;
                case ELogChannel.Info:
                    Debug.Log($"[Info] {message}");
                    break;
                case ELogChannel.Warning:
                    Debug.LogWarning($"[Warning] {message}");
                    break;
            }
        }
    }
}