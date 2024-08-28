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
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Hizmetler> Hizmetlers { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Duyurular> Duyurulars { get; set; }
        public DbSet<Haberler> Haberlers { get; set; }
        public DbSet<Galeri> Galeris { get; set; }

    }
}
