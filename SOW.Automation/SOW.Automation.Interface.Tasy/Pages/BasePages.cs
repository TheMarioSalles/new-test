using SOW.Automation.Common.WEB;
using SOW.Automation.Platform.WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Tasy.Pages
{
    public class BasePages
    {
        public WebAutomationServices _webServices;
        bool driverLoaded = false;

        public void CheckDriverLoaded(DriverContextInfo c)
        {
            if (!driverLoaded)
            {
                _webServices = new WebAutomationServices(c);
            }
        }
           
    }
}
