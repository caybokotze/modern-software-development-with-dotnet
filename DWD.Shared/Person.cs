using System.ComponentModel.DataAnnotations;

namespace DWD.Shared;

public interface IUser
{
    int Id { get; set; }
    string? Email { get; set; }
    string? Password { get; set; }
    int Age { get; set; }
}

public class User : IUser
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int Age { get; set; }
}