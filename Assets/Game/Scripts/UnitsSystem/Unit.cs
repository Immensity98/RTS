using Game.Scripts.System.Logger;
using UnityEngine;

namespace Game.Scripts.UnitsSystem
{
    public class Unit : MonoBehaviour
    {
        [field: SerializeField] public UnitModel Model { get; private set; }
        [field: SerializeField] public UnitView View { get; private set; }

        public void Initialize(UnitModel model,
            UnitView view)
        {
            if (model == null || view == null)
            {
                GameLogger.Log(Enums.ELogChannel.Error, "[Unit] Model or View is null!");
                return;
            }

            Model = model;
            View = view;
        }
    }
}