using Microsoft.EntityFrameworkCore;
using Rest.models;

namespace Rest.Models.Context
{
    public class MySqlContext :DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options): base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
