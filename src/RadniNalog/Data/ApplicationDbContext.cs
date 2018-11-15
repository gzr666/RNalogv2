using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RadniNalog.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using RadniNalog.Services;

namespace RadniNalog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
            
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Automobil> Automobili { get; set; }
        public DbSet<MjestoRada> MjestoRada { get; set; }
        public DbSet<RNalog> RadniNalozi { get; set; }
        public DbSet<VrstaRada> VrstaRada { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }
        public DbSet<Podrucje> Podrucja { get; set; }
        public DbSet<TipPostrojenja> TipoviPostrojenja { get; set; }
        public DbSet<TipDas> TipoviDas { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Automobil>().ToTable("Automobil");
            builder.Entity<MjestoRada>().ToTable("MjestoRada");
            builder.Entity<RNalog>().ToTable("RadniNalog");
            builder.Entity<VrstaRada>().ToTable("VrstaRada");
            builder.Entity<Zaposlenik>().ToTable("Zaposlenik");
            builder.Entity<Podrucje>().ToTable("Podrucja");
            builder.Entity<TipPostrojenja>().ToTable("TipPostrojenja");
            builder.Entity<TipDas>().ToTable("TipDas");



            //cascade deletions
            builder.Entity<RNalog>().HasOne(r => r.Automobil).WithMany(r => r.Nalozi).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RNalog>().HasOne(r => r.MjestoRada).WithMany(r => r.Nalozi).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RNalog>().HasOne(r => r.VrstaRada).WithMany(r => r.Nalozi).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<MjestoRada>().HasOne(r => r.TipDas).WithMany(r => r.MjestaRada).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RNalog>().OwnsOne(nalog => nalog.IspraveZaRad).ToTable("nalog_isprava_rad").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<RNalog>().OwnsOne(nalog => nalog.KategorijaRada).ToTable("nalog_kategorija_rad").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<RNalog>().OwnsOne(nalog => nalog.NadzorZaposlenika).ToTable("nalog_nadzor_zaposlenika").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<RNalog>().OwnsOne(nalog => nalog.ObukaZaposlenika).ToTable("nalog_obuka_zaposlenika").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<RNalog>().OwnsOne(nalog => nalog.OsiguranjeMjestaRada).ToTable("nalog_osiguranje_mjesta_rad").OnDelete(DeleteBehavior.Cascade);
            builder.Entity<RNalog>().OwnsOne(nalog => nalog.TipRada).ToTable("nalog_tip_rad").OnDelete(DeleteBehavior.Cascade);
            // builder.Entity<RNalog>().OwnsOne(nalog => nalog.IspraveZaRad).Property(x => x.DopusnicaIskljucenjeRad).HasColumnName("DopusnicaIskljucenjeRad1");
            //builder.Entity<RNalog>().OwnsOne(nalog => nalog.IspraveZaRad).Property(x => x.DopusnicaZaRad).HasColumnName("DopusnicaZaRad1");
            //builder.Entity<RNalog>().OwnsOne(nalog => nalog.IspraveZaRad).Property(x => x.IzjavaRukovoditelja).HasColumnName("IzjavaRukovoditelja1");


        }

        
    }
}
