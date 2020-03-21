using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Services.ServiceContracts
{
    public interface IAppConfiguartion
    {
        short ForgetKeyExpirationDays { get; }

        string FromUserEmail { get; }

        string PortalBaseUrl { get; }

        string CompanyName { get; }

        string ContactNumber { get; }

        string BusinessDaysAndHours { get; }
    }
}
