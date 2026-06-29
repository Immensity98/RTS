using Game.Scripts.Components;
using UnityEngine;
using Component = Game.Scripts.Components.Component;


namespace Game.Scripts.Factories
{
    public class ComponentFactory : IComponentFactory
    {
        public Component Create(ComponentData data)
        {
            if (data == null)
            {
                Debug.LogError($"[ComponentFactory] Data is null!");
                return null;
            }
            
            Component component = new Component();
            component.Init(data);
            return component;   
        }
    }
}
