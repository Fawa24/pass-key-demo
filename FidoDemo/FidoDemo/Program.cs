using FidoDemo.Db;
using FidoDemo.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FidoDemo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
			});

			builder.Services.AddIdentity<BaseUser, BaseRole>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders()
				.AddUserStore<UserStore<BaseUser, BaseRole, AppDbContext, string>>()
				.AddRoleStore<RoleStore<BaseRole, AppDbContext, string>>();

			var app = builder.Build();

			app.UseRouting();
			app.MapControllers();

			app.Run();
		}
	}
}
