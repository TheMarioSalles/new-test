using OpenQA.Selenium;
using SOW.Automation.Common;
using SOW.Automation.Common.Web;
using SOW.Automation.Driver.Selenium;

namespace SOW.Automation.Service.MondelezAra
{
    public class AutomationService
    {
        private WebDriverContextInfo _driverContextInfo;

        public WebDriverContextInfo DriverContextInfo
        {
            get { return _driverContextInfo; }
            set { _driverContextInfo = value; }
        }

        public IAutomationElement<IWebElement> BaseWebElement { get; private set; }

        public AutomationService(WebDriverContextInfo context)
        {
            this.DriverContextInfo = context;

            InitializeDriver();
        }

        private void InitializeDriver()
        {
            switch (this.DriverContextInfo.Driver)
            {
                case DriverEnum.Selenium:
                    BaseWebElement = new SeleniumAutomate<IWebElement>(this.DriverContextInfo);
                    break;
            }
        }
    }
}
