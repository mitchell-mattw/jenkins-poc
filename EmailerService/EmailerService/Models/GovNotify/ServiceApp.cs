using System.Collections.Generic;

namespace EmailerService.Models.GovNotify
{
    public class ServiceApp
    {
        public string Service { get; set; }

        public string Description { get; set; }
        public List<NotifyScheme> NotifySchemes { get; set; }

    }



   
}
