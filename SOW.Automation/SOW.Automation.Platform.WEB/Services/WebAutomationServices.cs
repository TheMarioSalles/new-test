using SOW.Automation.Common.WEB;
using SOW.Automation.Driver.Selenium;

namespace SOW.Automation.Platform.WEB.Services
{
    public class WebAutomationServices
    {
        private DriverContextInfo _driverContextInfo;

        //public IAutomationElement BaseWebElement { get; private set; }

        public WebAutomationServices(DriverContextInfo context)
        {
            _driverContextInfo = context;

            InitializeDriver();
        }

        private void InitializeDriver()
        {
            switch (_driverContextInfo.Driver)
            {
                //case DriverEnum.Selenium:
                //    BaseWebElement = new SeleniumAutomate(_driverContextInfo);
                //    break;
            }
        }
    }
}
