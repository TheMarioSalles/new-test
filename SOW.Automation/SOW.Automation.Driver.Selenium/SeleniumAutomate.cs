using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SOW.Automation.Common;
using SOW.Automation.Common.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Driver.Selenium
{
    public class SeleniumAutomate<T> : DriverBase, IAutomationElement<T> where T : IWebElement
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
            this.DriverContextInfo = config;

            InicializeDriver();
        }

        public void CloseProcess()
        {
            this.WebDriver.Close();
        }

        public void InicializeDriver()
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

        public void InsertTextInLabelByID(string labelID, string inputText, int seconds)
        {
            this.WebDriver.FindElement(By.Id(labelID)).SendKeys(inputText);
        }

        public void InsertTextInLabelByName(string labelName, string inputText, int seconds)
        {
            this.WebDriver.FindElement(By.Name(labelName)).SendKeys(inputText);
        }

        public void OpenURL(string url, int seconds)
        {
            this.WebDriver.Navigate().GoToUrl(url);
        }

        public void SearchAndClickByID(string ID, int seconds)
        {
            this.WebDriver.FindElement(By.Id(ID)).Click();
        }

        public T SearchAndReturnByID(string ID, int seconds)
        {
            return (T)this.WebDriver.FindElement(By.Id(ID));
        }

        public void TakeDefaultWindow()
        {
            //TODO
        }

        public void TakeScreenshot(string path, string name, bool printTimeSpan)
        {
            //TODO
        }
    }
}
