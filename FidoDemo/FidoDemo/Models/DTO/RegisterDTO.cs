﻿namespace FidoDemo.Models.DTO
{
	public class RegisterDTO
	{
		public string UserName { get; set; } = string.Empty;

		public string DisplayName { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		public string ConfirmPassword { get; set; } = string.Empty;
	}
}