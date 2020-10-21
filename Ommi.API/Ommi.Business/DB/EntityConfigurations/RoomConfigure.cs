using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ommi.Business.DB.Entities;

namespace Ommi.Business.DB.EntityConfigurations
{
	public class RoomConfigure : IEntityTypeConfiguration<Room>
	{
		public void Configure(EntityTypeBuilder<Room> builder)
		{
			builder.ToTable("Rooms");

			builder.Property(e => e.Id)
				.HasColumnName("Id")
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(e => e.Name)
				.HasColumnName("Name")
				.HasMaxLength(60)
				.IsUnicode(true)
				.IsRequired();

			builder.HasKey(e => e.Id);
		}
	}
}
