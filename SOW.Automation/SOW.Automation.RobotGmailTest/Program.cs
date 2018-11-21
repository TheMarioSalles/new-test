using SOW.Automation.Common;
using SOW.Automation.Common.Web;
using SOW.Automation.Interface.MondelezAra.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Robot.DHL
{
    public class Program
    {
        static void Main(string[] args)
        {
            LoginPage loginPage = new LoginPage(new WebDriverContextInfo
            {
                PathDriver = "",
                MaximizeWindow = true,
                Browser = BrowserEnum.Chrome,
                Driver = DriverEnum.Selenium,
                Timeout = 10
            });
            loginPage.OpenURL("http://169.57.166.44/mondelez_ara/", loginPage.DriverContextInfo);
            loginPage.EfetuarLogin("andre.l.dasilva@dhl.com", "Pri@1908");
            loginPage.Close(loginPage.DriverContextInfo);



            //loginPage.Close();

            //loginPage.SearchAndInsertDataByID("", "");
            //loginPage.SearchAndInsertDataByName("", "");
        }
    }
}
