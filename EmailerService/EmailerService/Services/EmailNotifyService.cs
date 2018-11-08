using System;
using EmailerService.Models;
using Microsoft.Extensions.Options;
using Notify.Client;
using Notify.Models.Responses;

namespace EmailerService.Services
{
    public interface IEmailNotifyService
    {
        EmailNotificationResponse SendEmail(TemplateOptions options);
    }

    public class EmailNotifyService : IEmailNotifyService
    {
        protected NotificationClient Client;
        private GovNotifySettings GovNotifySettings { get; set; }


        private void ConfigureNotifyClient()
        {
            Client=new NotificationClient(GovNotifySettings.Apikey);

        }

        public EmailNotifyService(IOptions<GovNotifySettings> settings)
        {
            GovNotifySettings = settings.Value;
            ConfigureNotifyClient();
        }

        
        public EmailNotificationResponse SendEmail(TemplateOptions options)
        {
            EmailNotificationResponse response = null;
            try
            {
                var serviceApp = GovNotifySettings.ServiceApps.Find(s => s.Service.ToUpper() == options.ServiceType.ToUpper());
                var notifyScheme = serviceApp.NotifySchemes.Find(n => n.Name == options.NotifyScheme);
                var templateId = notifyScheme.TemplateId;
                if (string.IsNullOrEmpty(templateId)) return null;
                options.Personalisation.Add("System", serviceApp.Description);
                response = Client.SendEmail(options.EmailAddress, templateId, options.Personalisation, null, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return response;
        }

        
    }
}
