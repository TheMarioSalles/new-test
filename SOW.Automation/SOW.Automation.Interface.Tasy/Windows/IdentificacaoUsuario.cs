using SOW.Automation.Interface.Tasy.Windows.Base;
using SOW.Automation.Service.Desktop;
namespace SOW.Automation.Interface.Tasy.Windows
{
    public class IdentificacaoUsuario : WindowBase
    {
        public IdentificacaoUsuario(DesktopService desktopService)
            : base(desktopService)
        {
            this.AutomationService = desktopService;
            Initialize();
        }

        private void Initialize()
        {
            Open();
            PreencherCampoUsuario();
            PreencherCampoSenha();
            ClicarBotaoOk();
        }

        private void Open()
        {
            this.AutomationService.BaseElement.OpenWindow("Identificação do Usuário", this.AutomationService.DriverContextInfo.Timeout);
        }

        private void ClicarBotaoOk()
        {
            this.AutomationService.BaseElement.SearchAndClickByText("OK", this.AutomationService.DriverContextInfo.Timeout);
        }

        private void PreencherCampoSenha()
        {
            var CampoSenha = this.AutomationService.BaseElement.SearchAndReturnByClassName("TEdit", this.AutomationService.DriverContextInfo.Timeout)[0];
            this.AutomationService.BaseElement.FieldFocus(CampoSenha, this.AutomationService.DriverContextInfo.Timeout);
            this.AutomationService.BaseElement.EnterKeys("unimed2018", this.AutomationService.DriverContextInfo.Timeout);
        }

        private void PreencherCampoUsuario()
        {
            var CampoUsuario = this.AutomationService.BaseElement.SearchAndReturnByClassName("TEdit", this.AutomationService.DriverContextInfo.Timeout)[1];
            this.AutomationService.BaseElement.FieldFocus(CampoUsuario, this.AutomationService.DriverContextInfo.Timeout);
            this.AutomationService.BaseElement.EnterKeys("plusoft", this.AutomationService.DriverContextInfo.Timeout);
        }
    }
}
