using Microsoft.EntityFrameworkCore;

namespace SUBD
{
	public class Context : DbContext
	{
		public Context()
		{
		}

		public Context(DbContextOptions<Context> options)
		: base(options)
		{
		}

		public virtual DbSet<Author> Authors { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=192.168.56.103;Port=5432;Database=news;Username=postgres;Password=54050");
	}
}