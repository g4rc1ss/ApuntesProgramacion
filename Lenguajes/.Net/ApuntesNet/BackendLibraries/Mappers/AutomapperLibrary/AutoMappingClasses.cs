using AutoMapper;
using AutomapperLibrary.Internal;

namespace AutomapperLibrary
{
    public class AutoMappingClasses
    {
        private readonly IMapper _mapper;

        public AutoMappingClasses(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Mapping()
        {
            var entidad = new PuebloEntity
            {
                Id = 1,
                Location = "Algun sitio",
                Name = "bilbao",
            };
            var response = _mapper.Map<PuebloEntityResponse>(entidad);
        }
    }
}
