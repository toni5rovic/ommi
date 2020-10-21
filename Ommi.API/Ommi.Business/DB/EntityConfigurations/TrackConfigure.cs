using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ommi.Business.DB.Entities;

namespace Ommi.Business.DB.EntityConfigurations
{
	public class TrackConfigure : IEntityTypeConfiguration<Track>
	{
		public void Configure(EntityTypeBuilder<Track> builder)
		{
			builder.ToTable("Tracks");

			builder.Property(e => e.Id)
				.HasColumnName("Id")
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(e => e.Steps)
				.HasColumnName("Steps")
				.HasMaxLength(64)
				.IsRequired();

			builder.Property(e => e.InstrumentName)
				.HasColumnName("InstrumentName");

			builder.Property(e => e.Volume)
				.HasColumnName("Volume");

			builder.Property(e => e.SoundName)
				.HasColumnName("SoundName");

			builder.HasKey(e => e.Id);
		}
	}
}
