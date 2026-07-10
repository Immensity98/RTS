using Game.Scripts.Enums;

namespace Game.Scripts.Systems.Filters
{
    public class FilterBuilder
    {
        private FilterMask _mask;
        private FilterService _service;

        public FilterBuilder(FilterMask mask, 
            FilterService service)
        {
            _mask = mask;
            _service = service;
        }

        public FilterBuilder Include(EComponentType type)
        {
            _mask.Add(type);
            return this;
        }

        public FilterBuilder Exclude(EComponentType type)
        {
            _mask.Remove(type);
            return this;
        }

        public Filter End()
        {
            return _service.GetFilter(_mask);
        }
    }
}