using System.ComponentModel.DataAnnotations;

namespace DWD.Shared;


public class Person
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int Age { get; set; }

}

public class User
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}