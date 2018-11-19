using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SOW.Automation.Driver.TestStack
{
    public class TestStackAutomate<T> : IAutomationElementTestStack<T> where T : IUIItem
    {
        private Application _application;
        public Application Application { get { return _application; } set { _application = value; } }

        private Window _window;
        public Window Window { get { return _window; } set { _window = value; } }

        private DesktopDriverContextInfo _driverContextInfo;
        public DesktopDriverContextInfo DriverContextInfo { get { return _driverContextInfo; } set { _driverContextInfo = value; } }

        public TestStackAutomate(DesktopDriverContextInfo config, string fullApplicationPath)
        {
            try 
	        {	        
                this.DriverContextInfo = config;

                InicializeDriver(fullApplicationPath);
	        }
	        catch (System.Exception)
	        {
		        throw;
	        }
        }

        public void CloseProcess() {
            try
            {
                this.Application.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void CloseWindow (int timeout)
        {
            try
            {
                this.Window.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void CloseWindow(string title, int timeout)
        {
            try
            {
                this.Application.GetWindow(title).Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InicializeDriver() { }

        public void InicializeDriver(string fullPath) {
            try
            {
                this.Application = Application.AttachOrLaunch(new System.Diagnostics.ProcessStartInfo(fullPath));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertTextInLabelByID(string labelID, string inputText, int seconds)
        {
            try
            {
                this.Window.GetElement(SearchCriteria.ByAutomationId(labelID)).SetFocus();
                this.Window.Keyboard.Enter(inputText);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertTextInLabelByName(string labelName, string inputText, int seconds)
        {
            try
            {
                this.Window.GetElement(SearchCriteria.ByClassName(labelName)).SetFocus();
                this.Window.Keyboard.Enter(inputText);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// It does nothing in Desktop level usage
        /// </summary>
        public void OpenURL(string url, int seconds) { }

        public void OpenApplication(string url, int seconds)
        {
            //Application
        }

        public void OpenWindow(string url, int seconds)
        {
            //Application
        }

        public void SearchAndClickByID(string ID, int seconds)
        {
            try
            {
                this.Window.Mouse.Location = this.Window.GetElement(SearchCriteria.ByAutomationId(ID)).GetClickablePoint();
                this.Window.Mouse.Click();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public T SearchAndReturnByID(string ID, int seconds)
        {
            try
            {
                return (T)this.Window.GetMultiple(SearchCriteria.ByAutomationId(ID))[0];// (T)this.Window.GetElement(SearchCriteria.ByAutomationId(ID));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void TakeDefaultWindow()
        {
            try
            {
                this.Window.Focus();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void TakeScreenshot(string path, string name, bool printTimeSpan)
        {
            try
            {
                //this.Window.Keyboard.PressSpecialKey();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
