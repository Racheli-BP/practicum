using Microsoft.Extensions.DependencyInjection;
using Repositories.Entities;
using Repositories.Interfaces;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositories
{
    public static class ServerCollection
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IEntity<Person>, PersonRepository>();
            service.AddScoped<IEntity<Child>, ChildRepository>();
			service.AddScoped<IEntity<Gender>, GenderRepository>();
			service.AddScoped<IEntity<HealthFund>, HealthFundRepository>();
		}
	}
}
