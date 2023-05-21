using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSerwice.model
{
    internal class ApplicationContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Credential> credential { get; set; }
        public ApplicationContext() : base("DefaultString")
        {

        }
    }
}
