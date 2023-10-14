using MapperlyLibrary.Internal;
using Riok.Mapperly.Abstractions;

namespace MapperlyLibrary.Profiles;

[Mapper]
public partial class PuebloMapper
{
    [MapProperty(nameof(@PuebloEntity.Id), nameof(@PuebloEntityResponse.Id))]
    [MapProperty(nameof(@PuebloEntity.Name), nameof(@PuebloEntityResponse.Nombre))]
    [MapProperty(nameof(@PuebloEntity.Location), nameof(@PuebloEntityResponse.Ubicacion))]
    public partial PuebloEntityResponse ToPuebloEntityResponse(PuebloEntity puebloEntity);
}
