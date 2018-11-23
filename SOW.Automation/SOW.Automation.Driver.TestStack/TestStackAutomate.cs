using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using System;
using System.Collections.Generic;
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

                InitializeDriver(this.DriverContextInfo.PathDriver, this.DriverContextInfo.Timeout);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void CloseProcess(int timeout)
        {
            try
            {
                this.Application.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void CloseWindow(int timeout)
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

        public void EnterKeys(string keys, int timeout)
        {
            this.Window.Keyboard.Enter(keys);
        }

        public void FieldFocus(T element, int timeout)
        {
            element.Focus();
        }

        public void InitializeDriver(int timeout) { throw new System.NotImplementedException(); }

        public void InitializeDriver(string fullPath, int timeout)
        {
            try
            {
                this.Application = Application.AttachOrLaunch(new System.Diagnostics.ProcessStartInfo(fullPath));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertTextByClassName(string fieldClassName, string insertText, int timeout)
        {
            try
            {
                this.Window.GetElement(SearchCriteria.ByClassName(fieldClassName));
                this.Window.Keyboard.Enter(insertText);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertTextByID(string fieldID, string insertText, int timeout)
        {
            try
            {
                this.Window.GetElement(SearchCriteria.ByAutomationId(fieldID));
                this.Window.Keyboard.Enter(insertText);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertTextByName(string fieldName, string insertText, int timeout)
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

        public void InsertTextByText(string fieldText, string insertText, int timeout)
        {
            try
            {
                this.Window.GetElement(SearchCriteria.ByText(fieldText)).SetFocus();
                this.Window.Keyboard.Enter(insertText);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void LeaveKey(KeyboardEnum key, int timeout)
        {
            this.Window.Keyboard.LeaveKey((SpecialKeys)key);
        }

        public void OpenApplication(string fullPath, int timeout)
        {
            try
            {
                this.Application = Application.AttachOrLaunch(new System.Diagnostics.ProcessStartInfo(fullPath));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OpenWindow(string url, int timeout)
        {
            try
            {
                this.Window = this.Application.GetWindow(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PressKey(KeyboardEnum key, int timeout)
        {
            this.Window.Keyboard.HoldKey((SpecialKeys)key);
        }

        public void SearchAndClickByClassName(string fieldClassName, int timeout)
        {
            try
            {
                this.Window.Get<Button>(SearchCriteria.ByClassName(fieldClassName)).Click();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void SearchAndClickByID(string ID, int timeout)
        {
            try
            {
                this.Window.Get<Button>(SearchCriteria.ByAutomationId(ID)).Click();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void SearchAndClickByName(string fieldName, int timeout)
        {
            throw new NotImplementedException();
        }

        public void SearchAndClickByText(string inputText, int timeout)
        {
            try
            {
                this.Window.Get<Button>(SearchCriteria.ByText(inputText)).Click();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IList<T> SearchAndReturnByClassName(string fieldClassName, int timeout)
        {
            try
            {
                var elements = this.Window.GetMultiple(SearchCriteria.ByClassName(fieldClassName));
                IList<T> elementsList = new List<T>();
                foreach (var item in elements) { elementsList.Add((T)item); }
                return elementsList;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public T SearchAndReturnByID(string ID, int timeout)
        {
            try
            {
                return this.Window.Get<T>(SearchCriteria.ByAutomationId(ID));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public T SearchAndReturnByName(string fieldName, int timeout)
        {
            throw new NotImplementedException();
        }

        public T SearchAndReturnByText(string fieldText, int timeout)
        {
            try
            {
                return this.Window.Get<T>(SearchCriteria.ByText(fieldText));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public T SearchAndReturnFirstByClassName(string fieldClassName, int timeout)
        {
            throw new NotImplementedException();
        }

        public void TakeDefaultWindow(int timeout)
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

        public void TakeScreenshot(string path, string name, bool printTimeSpan, int timeout)
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

        public void WaitWhileBusy(int timeout)
        {
            try
            {
                this.Window.WaitWhileBusy();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
