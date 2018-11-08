using System.Collections.Generic;

namespace EmailerService.Models
{
    public class TemplateOptions
    {
        public string EmailAddress { get; set; }
        //public string ProviderName { get; set; }
        public string ServiceType { get; set; }
        
        public string NotifyScheme { get; set; }
        
        public Dictionary<string, dynamic> Personalisation { get; set; }


    }

}
