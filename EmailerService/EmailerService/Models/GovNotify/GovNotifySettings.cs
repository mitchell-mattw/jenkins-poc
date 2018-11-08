using System.Collections.Generic;
using EmailerService.Models.GovNotify;

namespace EmailerService.Models
{
    public class GovNotifySettings
    {
        public string Apikey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<ServiceApp> ServiceApps { get; set; }
    }
}
