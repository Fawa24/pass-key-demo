using FidoDemo.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FidoDemo.Db
{
	public class AppDbContext : IdentityDbContext<BaseUser, BaseRole, string>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
		{

		}
	}
}
