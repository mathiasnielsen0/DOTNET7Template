using System;
using System.Collections.Generic;

namespace Website;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid? ResetPasswordGuid { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public bool Administrator { get; set; }
}
