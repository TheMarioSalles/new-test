using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Service.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Tasy.Windows
{
    public class ModuloPrincipal : WindowBase
    {
        public ModuloPrincipal(DesktopService desktopService) : base(desktopService)
        {
            this.AutomationService = desktopService;
            Initialize();
        }

        private void AtalhoMenu(ModuloPrincipalMenuEnum shortcut)
        {
            try
            {
                switch (shortcut)
                {
                    case ModuloPrincipalMenuEnum.ArquivoTrocarSenha:
                        Shortcut(KeyboardEnum.ALT, "at", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.ArquivoTrocarSetor:
                        Shortcut(KeyboardEnum.ALT, "ao", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.ArquivoTrocarEstabelecimento:
                        Shortcut(KeyboardEnum.ALT, "ac", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.ArquivoTrocarEspecialidade:
                        Shortcut(KeyboardEnum.ALT, "ae", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.ArquivoComunicaçãoInterna:
                        Shortcut(KeyboardEnum.ALT, "am", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.ArquivoAcesso:
                        Shortcut(KeyboardEnum.ALT, "aa", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.ArquivoCorCamposObrigatorios:
                        Shortcut(KeyboardEnum.ALT, "ad", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.ArquivoAlteracoesSistemaTasy:
                        Shortcut(KeyboardEnum.ALT, "al", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.ArquivoSair:
                        Shortcut(KeyboardEnum.ALT, "ar", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.Opcoes:
                        Shortcut(KeyboardEnum.ALT, "o", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.Estrutura:
                        Shortcut(KeyboardEnum.ALT, "e", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesParticular:
                        Shortcut(KeyboardEnum.ALT, "fp", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesCadastros:
                        Shortcut(KeyboardEnum.ALT, "fc", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesRelatorios:
                        Shortcut(KeyboardEnum.ALT, "fr", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesLocalizarFuncaoExecutar:
                        Shortcut(KeyboardEnum.ALT, "fl", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoControleDepositosIdentificados:
                        Shortcut(KeyboardEnum.ALT, "fac", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoFichaFinanceira:
                        Shortcut(KeyboardEnum.ALT, "faf", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSAutorizacoesIntercambio:
                        Shortcut(KeyboardEnum.ALT, "fao", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSBeneficiarioTratamento:
                        Shortcut(KeyboardEnum.ALT, "fap", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSComunicacaoInternacaoAltaBeneficiario:
                        Shortcut(KeyboardEnum.ALT, "fas", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSDossieBeneficiario:
                        Shortcut(KeyboardEnum.ALT, "fad", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSExecucaoRequisicaoAutorizacao:
                        Shortcut(KeyboardEnum.ALT, "fae", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSGestaoAnaliseAutorizacoes:
                        Shortcut(KeyboardEnum.ALT, "fag", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSGuiaMedico:
                        Shortcut(KeyboardEnum.ALT, "fau", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSIdentificacaoBeneficiarios:
                        Shortcut(KeyboardEnum.ALT, "fai", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSProcessoJudicial:
                        Shortcut(KeyboardEnum.ALT, "far", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSRequisicoesAutorizacao:
                        Shortcut(KeyboardEnum.ALT, "faq", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    case ModuloPrincipalMenuEnum.FuncoesAutorizacaoProtocoloDocumento:
                        Shortcut(KeyboardEnum.ALT, "fat", this.AutomationService.DriverContextInfo.Timeout);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Initialize()
        {
            Open("Philips Tasy - Módulo Principal", this.AutomationService.DriverContextInfo.Timeout);
            AtalhoMenu(ModuloPrincipalMenuEnum.FuncoesAutorizacaoOPSRequisicoesAutorizacao);
        }
    }
}
