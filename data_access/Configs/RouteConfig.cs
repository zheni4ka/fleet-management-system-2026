using business_logic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace data_access.Configs
{
    public class RouteConfig : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Routes");

            builder.HasOne(r => r.Auto)
                   .WithMany(a => a.Routes)
                   .HasForeignKey(r => r.AutoId);

            builder.HasOne(r => r.Driver)
                .WithMany(a => a.Routes)
                .HasForeignKey(r => r.DriverId);
        }
    }
}
