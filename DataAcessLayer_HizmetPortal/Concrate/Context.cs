using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer_HizmetPortal.Concrate
{
    public class Context:DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Hizmetler> Hizmetlers { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Duyurular> Duyurulars{ get; set; }
        public DbSet<Haberler> Haberlers { get; set; }

    }
}
