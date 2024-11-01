using System;
using System.Collections.Generic;

namespace KoiFishApp.Repositories.Entities;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? Username { get; set; }

    public string? FullName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public bool? Gender { get; set; }

    public string? Password { get; set; }

    public string? Image { get; set; }

    public bool? Status { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }
}
