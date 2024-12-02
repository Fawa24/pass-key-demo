using Microsoft.AspNetCore.Identity;

namespace FidoDemo.Models.IdentityEntities
{
	public class BaseUser : IdentityUser<string>
	{
		public string DisplayName { get; set; } = string.Empty;
	}
}
