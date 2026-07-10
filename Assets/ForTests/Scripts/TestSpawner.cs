using Game.Scripts.Data;
using Game.Scripts.Factories;
using Game.Scripts.UnitsSystem;
using System.Collections.Generic;
using Game.Scripts.Components;
using Game.Scripts.Enums;
using Game.Scripts.System.Logger;
using UnityEngine;
using VContainer;

namespace ForTests.Scripts
{
    public class TestSpawner : MonoBehaviour
    {
        public List<Unit> Units = new();
        public UnitData UnitData;
        public UnitData UnitData2;

        [Inject]
        public async void Spawn(UnitFactory factory)
        {
            var unit = await factory.CreateAsync(UnitData, ETeam.Player);
            var unit2 = await factory.CreateAsync(UnitData2, ETeam.AI1);


            Units.Add(unit);
            Units.Add(unit2);

            unit2.transform.position = new Vector3(5, 0, 5);

            GameLogger.Log(ELogChannel.Info, "Components from unit1 = " + unit.Model.Components.Count);
            GameLogger.Log(ELogChannel.Info, "Components from unit2 = " + unit2.Model.Components.Count);
        }
    }
}
