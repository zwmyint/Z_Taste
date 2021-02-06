using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Taste.Utility
{
    public class EmailSender : IEmailSender
    {
        //
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new System.NotImplementedException();
            //return Task.CompletedTask;
            //https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-3.0&tabs=visual-studio#create-full-identity-ui-source
            //https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=visual-studio#create-full-identity-ui-source
        }
    }
}