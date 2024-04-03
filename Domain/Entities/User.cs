using Data.Enums;

namespace Domain.Entities;

public class User : Base
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.User;
}
