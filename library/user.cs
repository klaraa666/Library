using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class user
    {
            public string PersonalNumber { get; set; }
            public string Password { get; set; }

        public user(string PersonalNumber, string Password)
        {
            this.PersonalNumber = PersonalNumber;
            this.Password = Password;
        }
        public void set(string PersonalNumber, string Password)
            {
                this.PersonalNumber = PersonalNumber;
                this.Password = Password;
            }
        
    }
}

