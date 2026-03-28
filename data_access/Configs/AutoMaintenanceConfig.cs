using business_logic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace data_access.Configs
{
    public class AutoMaintenanceConfig : IEntityTypeConfiguration<AutoMaintenance>
    {
        public void Configure(EntityTypeBuilder<AutoMaintenance> builder)
        {
            builder.ToTable("AutoMaintenance");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Auto)
                   .WithMany(a => a.Services)
                   .HasForeignKey(x => x.AutoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
