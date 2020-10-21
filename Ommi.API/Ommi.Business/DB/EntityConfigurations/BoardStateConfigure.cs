using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ommi.Business.DB.Entities;

namespace Ommi.Business.DB.EntityConfigurations
{
	public class BoardStateConfigure : IEntityTypeConfiguration<BoardState>
	{
		public void Configure(EntityTypeBuilder<BoardState> builder)
		{
			builder.ToTable("BoardStates");

			builder.Property(e => e.Id)
				.HasColumnName("Id")
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(e => e.Volume)
				.HasColumnName("Volume");

			builder.Property(e => e.TempoBPM)
				.HasColumnName("TempoBPM");

			builder.Property(e => e.NumberOfSteps)
				.HasColumnName("NumberOfSteps");

			builder.HasMany<Track>(e => e.Tracks)
				.WithOne(track => track.BoardState)
				.HasForeignKey(track => track.BoardStateId);

			builder.HasOne(e => e.Room)
				.WithOne(room => room.BoardState)
				.HasForeignKey<BoardState>(e => e.RoomId);

			builder.HasKey(e => e.Id);
		}
	}
}
