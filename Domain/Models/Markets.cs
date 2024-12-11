namespace Domain.Models;

public class Markets
{
    public int  Id { get; set; }
    public required string MarketName { get; set; }
    public required string Address { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public int UserId { get; set; }
}
