namespace CleanArchitecture.Domain.Database.ModelEntity;

public class UserLoginModelEntity
{
    public string LoginProvider { get; set; }
    public string ProviderKey { get; set; }
    public string ProviderDisplayName { get; set; }
    public int UserId { get; set; }
}
