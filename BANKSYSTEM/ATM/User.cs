﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class User
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
