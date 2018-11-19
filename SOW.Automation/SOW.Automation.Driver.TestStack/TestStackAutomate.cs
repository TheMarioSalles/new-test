using SOW.Automation.Common.Desktop;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using static TestStack.White.WindowsAPI.KeyboardInput;

namespace SOW.Automation.Driver.TestStack
{
    public class TestStackAutomate<T> : IDesktopExtendElement<T> where T : IUIItem
    {
        private Application _application;
        public Application Application { get { return _application; } set { _application = value; } }

        private Window _window;
        public Window Window { get { return _window; } set { _window = value; } }

        private DesktopDriverContextInfo _driverContextInfo;
        public DesktopDriverContextInfo DriverContextInfo { get { return _driverContextInfo; } set { _driverContextInfo = value; } }

        public TestStackAutomate(DesktopDriverContextInfo config)
        {
            try 
	        {	        
                this.DriverContextInfo = config;
	        }
	        catch (System.Exception)
	        {
		        throw;
	        }
        }

        public void CloseProcess(int seconds) {
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

        public void InicializeDriver(int seconds) { }

        public void InicializeDriver(string fullPath, int seconds) {
            try
            {
                this.Application = Application.AttachOrLaunch(new System.Diagnostics.ProcessStartInfo(fullPath));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertTextByID(string fieldID, string inputText, int seconds)
        {
            try
            {
                this.Window.GetElement(SearchCriteria.ByAutomationId(fieldID)).SetFocus();
                this.Window.Keyboard.Enter(inputText);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertTextByName(string fieldName, string inputText, int seconds)
        {
            throw new System.NotImplementedException();
            //
            //try
            //{
            //    this.Window.GetElement(SearchCriteria.(fieldName)).SetFocus();
            //    this.Window.Keyboard.Enter(inputText);
            //}
            //catch (System.Exception)
            //{
            //    throw;
            //}
        }

        public void InsertTextByClassName(string fieldClassName, string inputText, int seconds)
        {
            try
            {
                this.Window.GetElement(SearchCriteria.ByClassName(fieldClassName)).SetFocus();
                this.Window.Keyboard.Enter(inputText);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

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

        public void TakeDefaultWindow(int seconds)
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

        public void TakeScreenshot(string path, string name, bool printTimeSpan, int seconds)
        {
            try
            {
                this.Window.Keyboard.HoldKey(SpecialKeys.LWIN);
                this.Window.Keyboard.PressSpecialKey(SpecialKeys.PRINTSCREEN);
                this.Window.Keyboard.LeaveKey(SpecialKeys.LWIN);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
