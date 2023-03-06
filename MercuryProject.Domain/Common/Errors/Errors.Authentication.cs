﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace MercuryProject.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials =>
                Error.Validation(code: "Auth.InvalidCredentials", description: "Invalid Credentials");
        }
    }
}
