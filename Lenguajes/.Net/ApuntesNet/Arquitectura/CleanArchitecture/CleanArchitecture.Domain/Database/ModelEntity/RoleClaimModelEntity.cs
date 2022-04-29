namespace CleanArchitecture.Domain.Database.ModelEntity;

public class RoleClaimModelEntity
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}
