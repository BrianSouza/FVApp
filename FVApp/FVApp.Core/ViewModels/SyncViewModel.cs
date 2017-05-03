using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FVApp.Core.Dados.Entidades;
using FVApp.Core.Dados.Interface;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Validation;

namespace FVApp.Core.ViewModels
{
    public class SyncViewModel : MvxViewModel
    {
        IMvxToastService toastService;
        IFilialDados filialDados;
        IPedidosDados pedDados;
        IPedidosLinhasDados pedLinhasDados;
        IParceirosDados parcDados;
        ICondicoesPagamentoDados condDados;
        IFormasPagamentoDados formPagtoDados;

        public SyncViewModel()
        {

        }

        public override void Start()
        {
            //base.Start();
            toastService = Mvx.Resolve<IMvxToastService>();
            filialDados = Mvx.Resolve<IFilialDados>();
            pedDados = Mvx.Resolve<IPedidosDados>();
            pedLinhasDados = Mvx.Resolve<IPedidosLinhasDados>();
            parcDados = Mvx.Resolve<IParceirosDados>();
            condDados = Mvx.Resolve<ICondicoesPagamentoDados>();
            formPagtoDados = Mvx.Resolve<IFormasPagamentoDados>();
        }

        private bool _FormaPgtos;
        private bool _CondPagtos;
        private bool _Parceiros;
        private bool _Pedidos;
        private bool _Empresas;

        public bool FormaPgtos
        {
            get
            {
                return _FormaPgtos;
            }

            set
            {
                SetProperty(ref _FormaPgtos, value);
            }
        }

        public bool CondPagtos
        {
            get
            {
                return _CondPagtos;
            }

            set
            {
                SetProperty(ref _CondPagtos, value);
            }
        }

        public bool Parceiros
        {
            get
            {
                return _Parceiros;
            }

            set
            {
                SetProperty(ref _Parceiros, value);
            }
        }

        public bool Pedidos
        {
            get
            {
                return _Pedidos;
            }

            set
            {
                SetProperty(ref _Pedidos, value);
            }
        }

        public bool Empresas
        {
            get
            {
                return _Empresas;
            }

            set
            {
                SetProperty(ref _Empresas, value);
            }
        }

        public MvxCommand Sincronizar()
        {
            return new MvxCommand(Sync,ValidaSincronizacao);
        }
        private void Sync()
        {
            try
            {
                if (Empresas)
                {
                    SincronizarEmpresas();
                }

                if (Parceiros)
                {
                    SincronizarPN();
                }
                if (CondPagtos)
                {
                    SincronizarCP();
                }

                if (FormaPgtos)
                {
                    SincronizarFP();
                }

                if (Pedidos)
                {
                    SincronizarPedido();
                }
            }
            catch (Exception e)
            {
                string erro = e.Message;
                string msg = $"Ocorreu um problema ao realizar a sincronização: {erro}";
                toastService.DisplayError(msg);
            }
            
        }
        private void SincronizarEmpresas()
        {
            var empresas = filialDados.RetornarFiliais();

            foreach (var item in empresas)
            {
                filialDados.DeletarFilial(item);
            }

            //retorna lista de filiais para sincronizar e usar essa lista para adicionar as novas sincronizações

            //foreach (var item in collection)
            //{
            //    filialDados.SalvarFilial(item);
            //}
        }

        private void SincronizarPedido()
        {
            var pedidos = pedDados.RetornarPedidos();
            var pedidosParaSincronizar = pedidos.Where(t0 => t0.DocEntry.IsNullOrEmpty()).ToList();
            var linhasPedidosParaSincronizar = pedLinhasDados.RetornarLinhasPedidos();

            //sincronizar o pedidosParaSincronizar/linhasPedidosParaSincronizar e retornar a mesma lista com o docentry preenchido.

            foreach (var item in pedidosParaSincronizar)
            {
                List<PedidoLinhas> linhas = linhasPedidosParaSincronizar.Where(t0 => t0.KeyPedido.Equals(item.Key)).ToList();
                if(linhas.Count > 0)
                {
                    if (pedDados.SalvarPedidos(item))
                    {
                        ObservableCollection<PedidoLinhas> linhasOC = new ObservableCollection<PedidoLinhas>(linhas);
                        pedLinhasDados.SalvarLinhasPedidos(linhasOC);
                    }
                }

            }

        }

        private void SincronizarFP()
        {
            var todasFormas = formPagtoDados.RetornarFormasPagamento();
            foreach (var item in todasFormas)
            {
                if (!formPagtoDados.DeletarFormaPagamento(item))
                {
                    toastService.DisplayError($"Ocorreu um erro ao excluir a forma de pagamento {item.Descricao}.");

                }
            }

            //foreach (var formNova in collection)//Coleção vinda do serviço
            //{
            //    if (formPagtoDados.SalvarFormaPagamento(formNova))
            //    {
            //        toastService.DisplayError($"Ocorreu um erro ao incluir a condição de pgamento {formNova.Descricao}.");
            //        break;
            //    }
            //}
        }

        private void SincronizarCP()
        {
            var todasConds = condDados.RetornarCondicoes();
            foreach (var item in todasConds)
            {
                if (!condDados.DeletarCondicao(item))
                {
                    toastService.DisplayError($"Ocorreu um erro ao excluir a condição de pagamento {item.Descricao}.");

                }
            }

            //foreach (var condNova in collection)//Coleção vinda do serviço
            //{
            //    if (condDados.SalvarCondicao(condNova))
            //    {
            //        toastService.DisplayError($"Ocorreu um erro ao incluir a condição de pgamento {condNova.Descricao}.");
            //        break;
            //    }
            //}
        }

        private void SincronizarPN()
        {
            var todosParceiros = parcDados.RetornarParceiros();
            var parceirosNovos = todosParceiros.Where(t0 => t0.CardCode.IsNullOrEmpty()).ToList();
            //passar os novos parceiros para o serviço de integracao

            ////após receber os parceiro a ser sincronizados, deletar os atuais do mobile e acrescentar a nova lista
            //foreach (var pnNovo in collection)//Coleção vinda do serviço
            //{
            //    if (!parcDados.SalvarParceiro(pnNovo))
            //    {
            //        toastService.DisplayError($"Ocorreu um erro ao incluir o parceiro {pnNovo.CardName}.");
            //        break;
            //    }
            //}


            foreach (var pn in todosParceiros)
            {
                if (!parcDados.DeletarParceiro(pn))
                {
                    toastService.DisplayError($"Ocorreu um erro ao excluir o parceiro {pn.CardName}.");
                    break;
                }
            }
        }

        private bool ValidaSincronizacao()
        {
            if(FormaPgtos || CondPagtos || Parceiros || Pedidos || Empresas)
            {
                return true;
            }
            else
            {
                toastService.DisplayMessage("Selecione uma opção para sincronizar");
                return false;
            }
        }
    }
}
