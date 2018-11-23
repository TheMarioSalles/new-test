using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Interface.Tasy.Windows;
using SOW.Automation.Interface.Tasy.Windows.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Tasy
{
    public class Workflow
    {
        DesktopDriverContextInfo context = null;
        WindowBase wb = null;
        IdentificacaoUsuario identificacaoUsuario = null;
        ModuloPrincipal moduloPrincipal = null;
        RequisicoesAutorizacao requisicoesAutorizacao = null;
        IdentificacaoBeneficiarios identificacaoBeneficiarios = null;

        public Workflow()
        {
            try
            {
                context = new DesktopDriverContextInfo { PathDriver = @"C:\Users\Public\Desktop\Tasy.lnk", Driver = DriverEnum.TestStack, Timeout = 10 };
                wb = new WindowBase(context);
                identificacaoUsuario = new IdentificacaoUsuario(wb.AutomationService);
                moduloPrincipal = new ModuloPrincipal(wb.AutomationService);
                requisicoesAutorizacao = new RequisicoesAutorizacao(wb.AutomationService);
                identificacaoBeneficiarios = new IdentificacaoBeneficiarios(wb.AutomationService);
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (wb!=null) wb.Close(context.Timeout);
            }
        }
    }
}
