using AutoMapper;

using AutomapperLibrary.Internal;

namespace AutomapperLibrary;

public class AutoMappingClasses(IMapper mapper)
{

    public void Mapping()
    {
        var entidad = new PuebloEntity
        {
            Id = 1,
            Location = "Algun sitio",
            Name = "bilbao",
        };
        var response = mapper.Map<PuebloEntityResponse>(entidad);
    }
}
