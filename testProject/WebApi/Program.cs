using Services;

namespace WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddService();

			builder.Services.AddCors(opt => opt.AddPolicy("PolicyName", policy =>
			{
				policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
			}));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();
			app.UseCors(a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

			app.MapControllers();

			app.Run();
		}
	}
}