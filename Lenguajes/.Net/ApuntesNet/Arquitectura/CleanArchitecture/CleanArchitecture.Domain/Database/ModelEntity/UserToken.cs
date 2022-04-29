namespace CleanArchitecture.Domain.Database.ModelEntity;

public class UserToken
{
    public int UserId { get; set; }
    public string LoginProvider { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}
