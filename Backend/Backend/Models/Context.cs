using Backend.Models;
using System.Data.Entity;

namespace SchoolDataLayer
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext")
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<LongTermReservation> longTermReservations { get; set; }
        public DbSet<ShortTermReservation> shortTermReservations { get; set; }
    }
}