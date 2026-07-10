using Game.Scripts.Enums;
using Game.Scripts.System.Logger;
using VContainer.Unity;

namespace Game.Scripts.Systems.Filters
{
    public class FilterService : IInitializable
    {
        private FiltersStorage _storage;
        
        public FilterService(FiltersStorage storage)
        {
            _storage = storage;    
        }
        
        public FilterBuilder Create(EComponentType type)
        {
            var mask = new FilterMask();
            mask.Add(type);

            return new FilterBuilder(mask, this);
        }

        public Filter GetFilter(FilterMask mask)
        {
           return _storage.Get(mask);
        }

        public void Initialize()
        {
            GameLogger.Log(ELogChannel.System, "[FilterService] Service initialized");
        }
    }
}
