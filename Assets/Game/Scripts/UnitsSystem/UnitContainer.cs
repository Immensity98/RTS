using System;
using UnityEngine;

namespace Game.Scripts.UnitsSystem
{
    [Serializable]
    public class UnitContainer
    {
        [field: SerializeField] public UnitModel Model { get; private set; }
        [field: SerializeField] public UnitView View { get; private set; }

        public UnitContainer(UnitModel model,
            UnitView view)
        {
            Model = model;
            View = view;
        }
    }
}