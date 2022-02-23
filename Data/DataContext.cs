using System;
using EF_MOM_3_2.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_MOM_3_2.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<CD>? CD { get; set; }
		public DbSet<Artist>? Artist { get; set; }
		public DbSet<Customer>? Customer { get; set; }
	}
}

