using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IContext
	{
		public DbSet<Person> People { get; set; }

		public DbSet<Child> Children { get; set; }

		public DbSet<Gender> Genders { get; set; }

		public DbSet<HealthFund> HealthFunds { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

	}
}
