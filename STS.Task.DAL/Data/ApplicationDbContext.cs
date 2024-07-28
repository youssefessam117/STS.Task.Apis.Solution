using Microsoft.EntityFrameworkCore;
using STS.Task.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STS.Task.DAL.Data
{
	public class ApplicationDbContext : DbContext
	{
		private readonly DbContextOptions<ApplicationDbContext> options;

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			this.options = options;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.ApplyConfiguration( new ProductConfigurations() );

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<Product> Products { get; set; }

    }
}
