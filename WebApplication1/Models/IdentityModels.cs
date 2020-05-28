using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy ApplicationUser. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Jednostka> Jednostkas { get; set; }
        public DbSet<Jednostka_bazowa> Jednostka_Bazowas { get; set; }
      //  public DbSet<Kategoria> Kategorias { get; set; }
        public DbSet<Nazwa_nośnika> Nazwa_Nośnikas { get; set; }
        public DbSet<Nośnik_energii> Nośnik_Energiis { get; set; }
        public DbSet<Surowiec> Surowiecs { get; set; }
        public DbSet<Wielkosc_fizyczna> Wielkosc_Fizycznas { get; set; }
        public DbSet<Wspolczynnik> Wspolczynniks { get; set; }
        public DbSet<Wspolczynnik_Nazwa> współczynnik_Nazwas { get; set; }
        public DbSet<Zrodlo> Zrodlos { get; set; }
        public DbSet<Modul>Moduls {get; set; }
        public DbSet<Etap_Modul> Etap_Moduls { get; set; }
        public DbSet<Etap> Etaps { get; set; }
        public DbSet<Linie_Produkcyjne> Linie_Produkcyjnes { get; set; }
        public DbSet<Linie_Etap> Linie_Etaps { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}