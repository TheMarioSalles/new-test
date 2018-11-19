using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Driver.TestStack;
using TestStack.White.UIItems;

namespace SOW.Automation.Service.Tasy
{
    public class TasyService
    {
        private DesktopDriverContextInfo _driverContextInfo;

        public DesktopDriverContextInfo DriverContextInfo
        {
            get { return _driverContextInfo; }
            set { _driverContextInfo = value; }
        }

        public IAutomationElement<IUIItem> BaseWebElement { get; private set; }

        public TasyService(DesktopDriverContextInfo context)
        {
            this.DriverContextInfo = context;

            InitializeDriver();
        }

        private void InitializeDriver()
        {
            switch (this.DriverContextInfo.Driver)
            {
                case DriverEnum.TestStack:
                    BaseWebElement = new TestStackAutomate<IUIItem>(this.DriverContextInfo);
                break;
                //TODO
                //case DriverEnum.UIAutomation:
                //    BaseWebElement = new TestStackAutomate<IUIItem>(this.DriverContextInfo);
                //break;
            }
        }
    }
}
