using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SOW.Automation.Common.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Driver.Selenium
{
    public class SeleniumAutomate<T> : DriverBase, IWebAutomationElement<T> where T : IWebElement
    {
        private WebDriverContextInfo _driverContextInfo;

        public WebDriverContextInfo DriverContextInfo
        {
            get { return _driverContextInfo; }
            set { _driverContextInfo = value; }
        }

        private IWebDriver _webDriver;

        public IWebDriver WebDriver
        {
            get { return _webDriver; }
            set { _webDriver = value; }
        }

        public SeleniumAutomate(WebDriverContextInfo config)
        {
            try
            {
                this.DriverContextInfo = config;
                InicializeDriver(this.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CloseProcess(int seconds)
        {
            try
            {
                this.WebDriver.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InicializeDriver(int seconds)
        {
            try
            {
                switch (this.DriverContextInfo.Browser)
                {
                    case BrowserEnum.Chrome:
                        this.WebDriver = new ChromeDriver();
                        break;
                    case BrowserEnum.Edge:
                        this.WebDriver = new EdgeDriver();
                        break;
                    case BrowserEnum.FireFox:
                        this.WebDriver = new FirefoxDriver();
                        break;
                    case BrowserEnum.InternetExplorer:
                        this.WebDriver = new InternetExplorerDriver();
                        break;
                    default:
                        this.WebDriver = new ChromeDriver();
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertTextByID(string fieldID, string inputText, int seconds)
        {
            try
            {
                this.WebDriver.FindElement(By.Id(fieldID)).SendKeys(inputText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertTextByName(string fieldName, string inputText, int seconds)
        {
            try
            {
                this.WebDriver.FindElement(By.Name(fieldName)).SendKeys(inputText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertTextByClassName(string fieldClassName, string inputText, int seconds)
        {
            try
            {
                this.WebDriver.FindElement(By.ClassName(fieldClassName)).SendKeys(inputText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OpenURL(string url, int seconds)
        {
            try
            {
                this.WebDriver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SearchAndClickByID(string ID, int seconds)
        {
            try
            {
                this.WebDriver.FindElement(By.Id(ID)).Click();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T SearchAndReturnByID(string ID, int seconds)
        {
            try
            {
                return (T)this.WebDriver.FindElement(By.Id(ID));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void TakeDefaultWindow(int seconds)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void TakeScreenshot(string path, string name, bool printTimeSpan, int seconds)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
