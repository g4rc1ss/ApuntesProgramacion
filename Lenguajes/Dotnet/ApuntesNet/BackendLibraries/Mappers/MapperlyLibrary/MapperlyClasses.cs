using MapperlyLibrary.Internal;
using MapperlyLibrary.Profiles;

namespace MapperlyLibrary
{
    public class MapperlyClasses
    {
        public void Mapping()
        {
            var mapper = new PuebloMapper();
            var entidad = new PuebloEntity
            {
                Id = 1,
                Location = "Algun sitio",
                Name = "bilbao",
            };
            var response = mapper.ToPuebloEntityResponse(entidad);
        }
    }
}
