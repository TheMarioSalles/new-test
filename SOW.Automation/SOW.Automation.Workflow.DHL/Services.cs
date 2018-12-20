namespace SOW.Automation.Workflow.DHL
{
    public class Services
    {
        public Service.Desktop.DesktopService DesktopService;
        public Service.OCR.OCRService OCRService;
        public Service.Web.WebService WebService;
        public Services()
        {
            WebService = new Service.Web.WebService(
                new Common.Web.WebDriverContextInfo()
                {
                    Path = System.String.Concat(System.Environment.CurrentDirectory, "chromedriver.exe"),
                    MaximizeWindow = true,
                    Browser = Common.Web.BrowserEnum.Chrome,
                    Driver = Common.DriverEnum.Selenium,
                    Timeout = 100
                }
            );
            OCRService = new Service.OCR.OCRService(
                new Common.OCR.OCRDriverContextInfo()
                {
                    Driver = Common.DriverEnum.Sikuli,
                    Timeout = 120
                }
            );
            DesktopService = new Service.Desktop.DesktopService(
                new Common.Desktop.DesktopDriverContextInfo()
                {
                    Driver = Common.DriverEnum.TestStack,
                    Timeout = 100
                }
            );
        }
    }
}
