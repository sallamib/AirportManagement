using AM.Applicationcore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure;

public  class AMContext : DbContext //utiliser les methodes prededifinies de DbContext
{
    public DbSet<Plane> Planes { get; set; }

    public DbSet<Passenger> Passengers{ get; set; }

    public DbSet<Traveller> Travellers { get; set; }

    public DbSet<Staff> Staffs { get; set;}


    //onConfiguring : pour configurer la connexion a la base de donnée
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb; 
              Initial Catalog=AirportManagementDB;Integrated Security=true;MultipleActiveResultSets=True");
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLazyLoadingProxies();

    }
    //onModelCreating : pour configurer les entités

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlaneConfiguration()); //appele l configuration 
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        modelBuilder.ApplyConfiguration(new PassengerConfiguration());
        // direct in the methode : modelBuilder.Entity<Plane>().HasKey(p=>p.PlaneId);
        base.OnModelCreating(modelBuilder);
    }

    // onConfiguring : pour configurer les conventions convations is a set of rules that are applied to the model to configure the schema of the database
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //le Type des column DateTime est datek
        configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        //type de prop de type string ne depasse pas 250 
        configurationBuilder.Properties<string>().HaveMaxLength(250);
        //prop qui commence par code est une clé primaire
        //configurationBuilder.Properties()
        //    .Where(p => p.Name.StartsWith("Code"))
        //    .AreKey();
        //prop de type streing sont obligatoire 
        //configurationBuilder.Properties<string>().IsRequired();
    }

}
