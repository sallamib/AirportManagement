using AM.Applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations;

internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        //Configurer le type d’entité détenu FullName
      

        //La propriété FirstName a une longueur maximale de 30 et le nom de la colonne correspondante à cette propriété dans la base de données doit être PassFirstName
        builder.OwnsOne(p => p.FullName, fn =>
        {
            fn.Property(p => p.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
            fn.Property(p => p.LastName).IsRequired().HasColumnName("PassLastName").IsRequired();
        });

        //OwnsOne est une méthode qui permet de configurer un type d’entité détenu par une autre entité.
        //La propriété LastName est obligatoire et le nom de la colonne correspondante à cette propriété dans la base de données doit être PassLastName
        //builder.Property(p => p.FullName.LastName).IsRequired().HasColumnName("PassLastName");
    }
}
