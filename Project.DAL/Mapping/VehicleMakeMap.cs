using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Project.DAL.Entities;

namespace Project.DAL.Mapping
{
  public  class VehicleMakeMap : EntityTypeConfiguration<VehicleMake>
    {
        public VehicleMakeMap()
        {
            this.HasKey(t => t.MakeID);

            this.Property(t => t.MakeName);
            this.Property(t => t.MakeAbrv);

            this.ToTable("VehicleMake");
            this.Property(t => t.MakeName).HasColumnName("MakeName");
            this.Property(t => t.MakeAbrv).HasColumnName("MakeAbrv");
        }
    }
}
