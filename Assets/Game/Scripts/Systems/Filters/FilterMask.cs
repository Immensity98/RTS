using System.Collections.Generic;
using Game.Scripts.Enums;

namespace Game.Scripts.Systems.Filters
{
    public class FilterMask
    {
        public IReadOnlyCollection<EComponentType> Elements => _elements;
        private HashSet<EComponentType> _elements = new();
        
        public void Add(EComponentType element)
        {
            _elements.Add(element);
        }

        public void Remove(EComponentType element)
        {
            _elements.Remove(element);
        }
        
        public IReadOnlyCollection<EComponentType> GetElements() => Elements;
    }
}