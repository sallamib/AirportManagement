using AM.Applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations;
//class de congig qui utulise l'interface IEntityTypeConfiguration Fluent API 
public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        //■	Configurer la relation many-to-many entre la classe Flight et la classe Passenger
        builder.HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(e => e.ToTable("Reservation")); //rename association tbale to Reservation
    }
}


//Solid principles
//Single responsibility principle : A class should have one, and only one, reason to change.
//Open/closed principle : You should be able to extend a class’s behavior, without modifying it.
//Liskov substitution principle : Derived classes must be substitutable for their base classes.(separation des interfaces) cad si une classe derivee ne peut pas remplacer sa classe de base alors il faut separer les interfaces
//Interface segregation principle : Make fine grained interfaces that are client specific.
//Dependency inversion principle : Depend on abstractions, not on concretions. cad les classes de haut niveau ne doivent pas dependre des classes de bas niveau. Les deux doivent dependre des abstractions.

