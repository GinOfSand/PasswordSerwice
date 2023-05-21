using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSerwice.model
{
    internal class Credential
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User User { get; set; }
        public Service Service { get; set; }


    }
}
