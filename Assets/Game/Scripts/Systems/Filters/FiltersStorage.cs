using System.Collections.Generic;
using Game.Scripts.Enums;
using Game.Scripts.System.Logger;

namespace Game.Scripts.Systems.Filters
{
    public class FiltersStorage
    {
        private Dictionary<FilterMask, Filter> _filters = new();

        public void Add(FilterMask mask)
        {
            if (!_filters.ContainsKey(mask))
            {
                _filters.Add(mask, new Filter());
                
                GameLogger.Log(ELogChannel.System,
                    $"[FiltersStorage] Filter added. Current filters count: {_filters.Count}]");
            }
        }

        public void Remove(FilterMask mask)
        {
            if (_filters.ContainsKey(mask))
            {
                _filters.Remove(mask);
                
                GameLogger.Log(ELogChannel.System,
                    $"[FiltersStorage] Filter removed. Current filters count: {_filters.Count}]");
            }
        }

        public Filter Get(FilterMask mask)
        {
            return _filters.TryGetValue(mask, out var filter) 
                ? filter : null;
        }
    }
}