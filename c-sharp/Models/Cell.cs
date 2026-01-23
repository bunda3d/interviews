namespace Models;

public record Cell()
{
    public required bool IsMine { get; init; }
    public required bool IsGuessed { get; init; }
    public int Value { get; set; }
}