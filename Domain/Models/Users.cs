namespace Domain.Models;

public class Users
{
    public int Id { get; set; }
    public required  string? Username { get; set; }
    public  string?  FirstName { get; set; }
    public string? Lastname { get; set; }
    public required string? Phone { get; set; }
    public  string?  Address{ get; set; }
    public required string? Email { get; set; }
    public DateTime BirthDate { get; set; }

    
}







