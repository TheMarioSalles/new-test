using SOW.Automation.Common.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.MondelezAra.Pages
{
    public class LoginPage : PageBase
    {
        private WebDriverContextInfo _driverContextInfo;

        public WebDriverContextInfo DriverContextInfo
        {
            get { return _driverContextInfo; }
            set { _driverContextInfo = value; }
        }

        public LoginPage(WebDriverContextInfo driverContextInfo) : base(driverContextInfo)
        {
            this.DriverContextInfo = driverContextInfo;
        }

        public void EfetuarLogin(string usuario, string senha)
        {
            Console.WriteLine(""
                + "Usuário: "
                + usuario
                + "\n"
                + "Senha: "
                + senha
                );
            PreencherCampoTextoUsuario(usuario);
            PreencherCampoTextoSenha(senha);
            ClicarBotaoEntrar();
        }

        public void PreencherCampoTextoUsuario(string value)
        {
            this.AutomationService.BaseWebElement.InsertTextInLabelByID("TextBox_Usuario", value, this.DriverContextInfo.Timeout);
        }

        public void PreencherCampoTextoSenha(string value)
        {
            this.AutomationService.BaseWebElement.InsertTextInLabelByID("TextBox2", value, this.DriverContextInfo.Timeout);
        }

        public void ClicarBotaoEntrar()
        {
            this.AutomationService.BaseWebElement.SearchAndClickByID("ButtonEntra", this.DriverContextInfo.Timeout);
        }

        public void ClicarBotaoEsqueciSenha()
        {
            this.AutomationService.BaseWebElement.SearchAndClickByID("ButtonEsquecii", this.DriverContextInfo.Timeout);
        }
    }
}
