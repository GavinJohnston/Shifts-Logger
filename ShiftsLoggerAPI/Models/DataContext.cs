using System;
using Microsoft.EntityFrameworkCore;

namespace ShiftsLoggerAPI.Models
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) {}
			public DbSet<Shifts> ShiftsTable { get; set; }
	}
}

// CODE FIRST MIGRATION
//
// Commands: 
// dotnet ef
// dotnet ef migrations add createinitial
// dotnet ef database update