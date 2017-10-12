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
    public class VehicleModelMap : EntityTypeConfiguration<VehicleModel>
    {
        public VehicleModelMap()
        {
            this.HasKey(t => t.ModelID);

            this.Property(t => t.ModelName);
            this.Property(t => t.ModelAbrv);

            this.ToTable("VehicleModel");
            this.Property(t => t.ModelName).HasColumnName("ModelName");
            this.Property(t => t.ModelAbrv).HasColumnName("modelAbrv");

            this.HasRequired(t => t.VehicleMake).WithMany(t => t.VehicleModels).HasForeignKey(b => b.VehicleMake);
        }
    }
}
