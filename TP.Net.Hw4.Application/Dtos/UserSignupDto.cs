﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Net.Hw4.Application.Dtos
{
    public class UserSignupDto
    {
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
