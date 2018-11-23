using SOW.Automation.Common;
using SOW.Automation.Service.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Tasy.Windows
{
    public class RequisicoesAutorizacao : WindowBase
    {
        public RequisicoesAutorizacao(DesktopService desktopService) : base(desktopService)
        {
            this.AutomationService = desktopService;
            Initialize();
        }

        private void Initialize()
        {
            ClicarBotaoNovo();
        }

        private void ClicarBotaoFechar()
        {
            try
            {
                Shortcut(KeyboardEnum.ALT, "F", this.AutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClicarBotaoExcluir()
        {
            try
            {
                Shortcut(KeyboardEnum.ALT, "E", this.AutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClicarBotaoDesfazer()
        {
            try
            {
                Shortcut(KeyboardEnum.ALT, "D", this.AutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClicarBotaoSalvar()
        {
            try
            {
                Shortcut(KeyboardEnum.ALT, "S", this.AutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClicarBotaoNovo()
        {
            try
            {
                Shortcut(KeyboardEnum.ALT, "N", this.AutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClicarBotaoVisualizar()
        {
            try
            {
                Shortcut(KeyboardEnum.ALT, "V", this.AutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClicarBotaoImprimir()
        {
            try
            {
                Shortcut(KeyboardEnum.ALT, "I", this.AutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClicarBotaoDetalhe()
        {
            try
            {
                Shortcut(KeyboardEnum.ALT, "H", this.AutomationService.DriverContextInfo.Timeout);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
