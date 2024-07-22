﻿using Microsoft.AspNetCore.Identity;

namespace Bloqqer.DataAccess.Models;

public sealed class ApplicationRole : IdentityRole<Guid>
{
    public const string SuperUser = "SUPER_USER";

    public const string Admin = "ADMIN";

    public const string User = "USER";
}