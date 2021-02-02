using Microsoft.EntityFrameworkCore;
using Rest.models;

namespace Rest.Models.Context
{
    public class MySqlContext :DbContext
    {
        public MySqlContext()
        {

        }
        public MySqlContext(DbContextOptions<MySqlContext> options): base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }



    }
}
