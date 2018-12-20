using SOW.Automation.Interface.Dlx.Excel.Models;
using System.Collections.Generic;
using System.Linq;

namespace SOW.Automation.Interface.Dlx.Excel.Services
{
    public class BlocosGeraisDisponiveisService
    {
        private static List<DetalhesBlocosDisponiveis> AplicaRegrasDePrioridadeMapaGeral(Enums.EStatusStageDlx familiaDlx, IList<FamiliaStages> familaStages)
        {
            var Opcao1 = new List<DetalhesBlocosDisponiveis>();
            var Opcao2 = new List<DetalhesBlocosDisponiveis>();
            var Lista = DetalhesStagesDisponiveisMapaGeral(familaStages.ToList());
            switch (familiaDlx)
            {
                case Enums.EStatusStageDlx.AMB:
                    Opcao1 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.AMBIENTE);
                    Opcao2 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    return Opcao1.Count > 0 ? Opcao1 : Opcao2;
                case Enums.EStatusStageDlx.CLI:
                    Opcao1 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    Opcao2 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    return Opcao1.Count > 0 ? Opcao1 : Opcao2;
                case Enums.EStatusStageDlx.PAS:
                    Opcao1 = Lista
                             .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    Opcao2 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    return Opcao1.Count > 0 ? Opcao1 : Opcao2;
                case Enums.EStatusStageDlx.SEM:
                    Opcao1 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1;
                case Enums.EStatusStageDlx.AMBCLI:
                    Opcao1 = Lista
                             .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    Opcao2 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1.Count > 0 ? Opcao1 : Opcao2;
                case Enums.EStatusStageDlx.AMBPAS:
                    Opcao1 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    Opcao2 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1.Count > 0 ? Opcao1 : Opcao2;
                case Enums.EStatusStageDlx.CLIPAS:
                    Opcao1 = Lista
                              .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    Opcao2 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1.Count > 0 ? Opcao1 : Opcao2;
                default:
                    return Opcao1;
            }
        }
        private static List<FamiliaStages> AplicaRegrasDePrioridade(Enums.EStatusStageDlx familiaDlx, IList<FamiliaStages> familaStages)
        {
            var Opcao1 = new List<FamiliaStages>();
            var Lista = familaStages.ToList();
            switch (familiaDlx)
            {
                case Enums.EStatusStageDlx.AMB:
                    Opcao1 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.AMBIENTE || a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    return Opcao1.OrderBy(a => a.Familia).ToList();
                case Enums.EStatusStageDlx.CLI:
                    Opcao1 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA || a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    return Opcao1.OrderBy(a => a.Familia).ToList();
                case Enums.EStatusStageDlx.PAS:
                    Opcao1 = Lista
                             .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA || a.Familia == Enums.EFamiliaStages.REVERSÍVEL);
                    return Opcao1.OrderBy(a => a.Familia).ToList();
                case Enums.EStatusStageDlx.SEM:
                    Opcao1 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1;
                case Enums.EStatusStageDlx.AMBCLI:
                    Opcao1 = Lista
                             .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL || a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1.OrderByDescending(a => a.Familia).ToList();
                case Enums.EStatusStageDlx.AMBPAS:
                    Opcao1 = Lista
                             .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL || a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1.OrderByDescending(a => a.Familia).ToList();
                case Enums.EStatusStageDlx.CLIPAS:
                    Opcao1 = Lista
                             .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL || a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1.OrderByDescending(a => a.Familia).ToList();
                default:
                    return Opcao1;
            }
        }



        public static List<DetalhesBlocosDisponiveis> DetalhesStagesDisponiveisMapaGeral(List<FamiliaStages> familaStages)
        {
            List<StagesDisponiveis> LStagesDisponiveis = new List<Models.StagesDisponiveis>();
            StagesDisponiveis sta = new Models.StagesDisponiveis();
            int cont = 0;
            int contGeral = 0;
            int Palets = 0;
            foreach (var fam in familaStages)
            {
                if ((fam.MsVazio && fam.StatusVazio || fam.Status == Enums.EStatusStage.Load_Complete || fam.MsVazio && !fam.StatusVazio) && !fam.StageColuna)
                {
                    cont++;
                    Palets += fam.CapacidadeStage;
                }
                    

                else if (fam.MsVazio == false && fam.StatusVazio == false || fam.Status != Enums.EStatusStage.Load_Complete)
                {
                    if (cont != 0)
                    {
                        sta = new Models.StagesDisponiveis
                        {
                            QtdStageDisponivel = cont,
                            Familia = fam.Familia,
                            LinhaColuna = fam.LinhaColuna,
                            Coluna = fam.Coluna,
                            QtdPalets = Palets
                        };
                        sta.LinhaColuna -= cont == 1 ? 0 : cont - 1;
                        LStagesDisponiveis.Add(sta);
                        cont = 0;
                        Palets = 0;
                    }
                }

                if (familaStages.Count == contGeral + 1)
                {
                    if ((fam.MsVazio && fam.StatusVazio || fam.Status == Enums.EStatusStage.Load_Complete || fam.MsVazio && !fam.StatusVazio) && !fam.StageColuna)
                    {
                        sta = new Models.StagesDisponiveis
                        {
                            QtdStageDisponivel = cont,
                            Familia = fam.Familia,
                            LinhaColuna = fam.LinhaColuna,
                            Coluna = fam.Coluna,
                            QtdPalets = Palets
                        };
                        sta.LinhaColuna -= cont == 1 ? 0 : cont;
                        LStagesDisponiveis.Add(sta);
                        cont = 0;
                        Palets = 0;
                    }
                }
                contGeral++;
            }


            List<DetalhesBlocosDisponiveis> Detalhes = new List<DetalhesBlocosDisponiveis>();
            var Grupo = LStagesDisponiveis.GroupBy(a => a.QtdStageDisponivel).ToList();

            for (int i = 0; i < Grupo.Count; i++)
            {
                var GrupoFamilias = Grupo[i].ToList().GroupBy(a => a.Familia).ToList();
                for (int k = 0; k < GrupoFamilias.Count(); k++)
                {
                    DetalhesBlocosDisponiveis det = new DetalhesBlocosDisponiveis
                    {
                        Familia = GrupoFamilias[k].Key,
                        TamanhoBloco = Grupo[i].Key,
                        QtdBlocoLivre = GrupoFamilias[k].Count()
                    };
                    foreach (var item in GrupoFamilias[k])
                    {
                      CoordenadaElementoStage c = new CoordenadaElementoStage { PolicaoLinha = item.LinhaColuna, PosicaoColunas = item.Coluna, QtdPalets = item.QtdPalets };
                    }
                    Detalhes.Add(det);
                }
            }
            Detalhes = Detalhes.OrderBy(a => a.Familia).ToList();
            return Detalhes;
        }
        public static CoordenadasExcelWriter DetalhesStagesDisponiveis(List<FamiliaStages> familaStages, RpaDadosStageInfo rpaDados)
        {
            var ListaComRegraOpcoes  = AplicaRegrasDePrioridade(rpaDados.FamiliaDlx,familaStages.ToList());
            List<CoordenadasExcelWriterDetalhes> ListaCoordenadas = new List<CoordenadasExcelWriterDetalhes>();
            CoordenadasExcelWriterDetalhes coordenada;
            int cont = 0;
            int Palets = 0;
            var qtdPaletsGeral = rpaDados.QtdPalets;
            foreach (var fam in ListaComRegraOpcoes)
            {
                
                if ((fam.MsVazio && fam.StatusVazio || fam.Status == Enums.EStatusStage.Load_Complete || fam.MsVazio && !fam.StatusVazio) && !fam.StageColuna)
                {
                    coordenada = new CoordenadasExcelWriterDetalhes
                    {
                        PolicaoLinha = fam.LinhaColuna + 1,
                        Colunas = fam.Colunas,
                        QtdPalets = fam.CapacidadeStage
                    };

                    if (!(rpaDados.QtdPalets <= 0))
                        ListaCoordenadas.Add(coordenada);
            

                    rpaDados.QtdPalets -= fam.CapacidadeStage;

                    if (rpaDados.QtdPalets <= 0)
                        break;

                    cont++;
                    Palets += fam.CapacidadeStage;
                }
                else
                {
                    if(!(rpaDados.QtdPalets <=0 ))
                    {
                        rpaDados.QtdPalets = qtdPaletsGeral;
                        ListaCoordenadas = new List<CoordenadasExcelWriterDetalhes>();
                    }
                }
            }

            rpaDados.QtdPalets = qtdPaletsGeral;
          

          

            CoordenadasExcelWriter Coordenada = new CoordenadasExcelWriter();
            Coordenada.Detalhes = ListaCoordenadas;
            Coordenada.DadosRpa = rpaDados;
           

            if (ListaCoordenadas.Count > 0)
                Coordenada.CoordenadaDisponivel = true;
            else
                Coordenada.CoordenadaDisponivel = false;

            return Coordenada;
        }
    }
}
