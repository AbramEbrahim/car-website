using Microsoft.AspNetCore.Identity.UI.Services;

namespace car_web.Utility
{
	public class EmailService : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			//logicEmail
			 return Task.CompletedTask;
		}
	}
}
