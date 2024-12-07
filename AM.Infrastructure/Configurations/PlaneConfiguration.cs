using AM.Applicationcore;
using AM.Applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AM.Infrastructure.Configurations;

public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
{
    public void Configure(EntityTypeBuilder<Plane> builder)
    {
        builder.HasKey(p=>p.PlaneId);
        builder.ToTable("MyPlanes"); //rename table 
        builder.Property(p=>p.Capacity).HasColumnName("PlaneCapacity"); //rename column 

        //Configurer la relation one-to - many entre la classe Flight et la classe Plane

        builder.HasMany(p=>p.Flights).WithOne(f=>f.Plane).HasForeignKey(f=>f.PlaneFK).OnDelete(DeleteBehavior.Cascade);
       
    }
    //Diff between DateTime and DateTime2 : DateTime2 is more precise than DateTime and also it is the default type for date and time in SQL Server.
    //DateTime2 is more precise than DateTime and also it is the default type for date and time in SQL Server.
}
