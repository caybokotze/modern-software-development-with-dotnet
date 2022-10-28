using System.ComponentModel.DataAnnotations;

namespace DWD.Shared;

public interface IAdministrator
{
    public bool IsAdministrator { get; set; }
}

public interface ISecretary
{
    public bool IsSecretary { get; set; }
}

public class Person : IAdministrator, ISecretary
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int Age { get; set; }

    public bool IsAdministrator { get; set; }
    public bool IsSecretary { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}