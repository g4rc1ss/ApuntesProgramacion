namespace SerilogLibrary;

public record UserDTO
{
    public required string Name { get; init; }
    public required string SurName { get; init; }
    public required string Email { get; init; }
    public required string MerchantId { get; init; }
    public required string TerminalId { get; init; }
}
