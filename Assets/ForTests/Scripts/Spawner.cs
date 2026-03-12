using System;
using System.Collections.Generic;
using Game.Scripts.Data;
using Game.Scripts.Factories;
using Game.Scripts.UnitsSystem;
using UnityEngine;
using VContainer;

namespace ForTests.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public List<UnitContainer> Units = new();
        private UnitFactory _factory;
        public UnitData UnitData;
        public UnitData UnitData2;

        [Inject]
        public async void Spawn(UnitFactory factory)
        {
            var unit = await factory.CreateAsync(UnitData);
            var unit2 = await factory.CreateAsync(UnitData2);
            
            Units.Add(unit);
            Units.Add(unit2);

           Debug.Log("Components from unit1 = " + unit.Model.Components.Count);
           Debug.Log("Components from unit2 = " + unit2.Model.Components.Count);
        }
    }
}
