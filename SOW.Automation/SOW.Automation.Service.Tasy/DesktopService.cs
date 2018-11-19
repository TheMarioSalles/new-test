using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Driver.TestStack;
using TestStack.White.UIItems;

namespace SOW.Automation.Service.Desktop
{
    public class DesktopService
    {
        private DesktopDriverContextInfo _driverContextInfo;

        public DesktopDriverContextInfo DriverContextInfo
        {
            get { return _driverContextInfo; }
            set { _driverContextInfo = value; }
        }

        public IDesktopExtendElement<IUIItem> BaseElement;

        public DesktopService(DesktopDriverContextInfo context)
        {
            this.DriverContextInfo = context;

            InitializeDriver();
        }

        private void InitializeDriver()
        {
            switch (this.DriverContextInfo.Driver)
            {
                case DriverEnum.TestStack:
                    BaseElement = new TestStackAutomate<IUIItem>(this.DriverContextInfo);
                break;
                //TODO
                //case DriverEnum.UIAutomation:
                //    BaseWebElement = new TestStackAutomate<IUIItem>(this.DriverContextInfo);
                //break;
            }
        }
    }
}
