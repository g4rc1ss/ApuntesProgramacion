namespace CleanArchitecture.Domain.Database.ModelEntity;

public class RoleModelEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public string ConcurrencyStamp { get; set; }
}
