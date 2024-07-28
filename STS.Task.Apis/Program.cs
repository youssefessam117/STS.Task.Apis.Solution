
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STS.Task.Apis.Helpers;
using STS.Task.BLL;
using STS.Task.BLL.Interfaces;
using STS.Task.BLL.Services;
using STS.Task.DAL.Data;

namespace STS.Task.Apis
{
	public class Program
	{
		public static async System.Threading.Tasks.Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<ApplicationDbContext>(option =>
			{
				option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

			builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));

			builder.Services.AddAutoMapper(typeof(MappingProfiles));
			builder.Services.AddCors(option =>
			{
				option.AddPolicy("MyPolicy", policyOptions =>
				{
					policyOptions.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration["FrontBaseUrl"] ?? "");
				});
			});
			var app = builder.Build();

			#region apply all pending migrations [update-database] and data seeding
			using var scop = app.Services.CreateScope();

			var services = scop.ServiceProvider;

			var _dbContext = services.GetRequiredService<ApplicationDbContext>();// ask clr for creating object from dbcontext explicitly
			
			await _dbContext.Database.MigrateAsync();// update database 
			await ApplicationDbContextSeed.SeedAsync(_dbContext);
			#endregion

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseStaticFiles();

			app.UseCors("MyPolicy");

			app.MapControllers();

			app.Run();
		}
	}
}
