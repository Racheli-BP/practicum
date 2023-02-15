using Common.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Repositories;
using repositories;
using Repositories;
using DBContext;
using Services.ServiceEntities;

namespace Services
{
    public static class ServiceCollectionExtention
    {
		public static IServiceCollection AddService(this IServiceCollection services)
		{
			services.AddRepositories();

			services.AddScoped<IService<PersonDTO>, PersonService>();
			services.AddScoped<IService<ChildDTO>, ChildService>();
			services.AddScoped<IService<HealthFundDTO>, HealthFundService>();
			services.AddScoped<IService<GenderDTO>, GenderService>();

			services.AddSingleton<IContext, Context>();
			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}

	}
}
