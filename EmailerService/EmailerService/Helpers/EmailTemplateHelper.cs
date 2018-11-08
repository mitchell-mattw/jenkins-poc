using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EmailerService.Enums;
using EmailerService.Models;
using EmailerService.Models.GovNotify;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NotifyType = EmailerService.Enums.NotifyType;

namespace EmailerService.Helpers
{
    public static class EmailTemplateHelper
    {
        public static string GetTemplateId(string strServiceType,  string strNotifyType)
        {
            Enum.TryParse(strServiceType, out ServiceType serviceType);
            Enum.TryParse(strNotifyType, out NotifyType notifyType);

            switch (serviceType)
            {
                case ServiceType.AscPic:

                    switch (notifyType)
                    {

                        case NotifyType.Email:
                            
                            break;

                        case NotifyType.Letter:
                            break;

                        case NotifyType.Sms:
                            break;

                    }


                    break;
                case ServiceType.GpPic:

                    switch (notifyType)
                    {

                        case NotifyType.Email:
                            break;

                        case NotifyType.Letter:
                            break;

                        case NotifyType.Sms:
                            break;

                    }

                    break;
                case ServiceType.Registration:

                    switch (notifyType)
                    {

                        case NotifyType.Email:
                            break;

                        case NotifyType.Letter:
                            break;

                        case NotifyType.Sms:
                            break;

                    }
                    break;
            }


            return "";
        }

    }
}
