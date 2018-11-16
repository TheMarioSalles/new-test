using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SOW.Automation.Driver.TestStack
{
    public class TestStackAutomate<T> : IAutomationElement<T> where T : IUIItem
    {
        private DesktopDriverContextInfo _driverContextInfo;

        public DesktopDriverContextInfo DriverContextInfo
        {
            get { return _driverContextInfo; }
            set { _driverContextInfo = value; }
        }

        private Window _window;

        public Window Window
        {
            get { return _window; }
            set { _window = value; }
        }

        public TestStackAutomate(DesktopDriverContextInfo config)
        {
            this.DriverContextInfo = config;

            InicializeDriver();
        }

        public void CloseProcess() { this.Window.Close(); }

        public void InicializeDriver() { }

        public void InsertTextInLabelByID(string labelID, string inputText, int seconds)
        {
            this.Window.GetElement(SearchCriteria.ByAutomationId(labelID)).SetFocus();
            this.Window.Keyboard.Enter(inputText);
        }

        public void InsertTextInLabelByName(string labelName, string inputText, int seconds)
        {
            this.Window.GetElement(SearchCriteria.ByClassName(labelName)).SetFocus();
            this.Window.Keyboard.Enter(inputText);
        }

        /// <summary>
        /// It does nothing in Desktop level usage
        /// </summary>
        public void OpenURL(string url, int seconds) { }

        public void OpenApplication(string url, int seconds)
        {
            //Application
        }

        public void SearchAndClickByID(string ID, int seconds)
        {
            this.Window.Mouse.Location = this.Window.GetElement(SearchCriteria.ByAutomationId(ID)).GetClickablePoint();
            this.Window.Mouse.Click();
        }

        public T SearchAndReturnByID(string ID, int seconds)
        {
            return (T)this.Window.GetMultiple(SearchCriteria.ByAutomationId(ID))[0];// (T)this.Window.GetElement(SearchCriteria.ByAutomationId(ID));
        }

        public void TakeDefaultWindow()
        {
            this.Window.Focus();
        }

        public void TakeScreenshot(string path, string name, bool printTimeSpan)
        {
            //this.Window.Keyboard.PressSpecialKey()
        }
    }
}
