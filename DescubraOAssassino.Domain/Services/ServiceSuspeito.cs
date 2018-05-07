using DescubraOAssassino.Domain.Arguments.Base;
using DescubraOAssassino.Domain.Arguments.Suspeito;
using DescubraOAssassino.Domain.Entities;
using DescubraOAssassino.Domain.Inferfaces.Repositories;
using DescubraOAssassino.Domain.Inferfaces.Services;
using DescubraOAssassino.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DescubraOAssassino.Domain.Services
{
    public class ServiceSuspeito : Notifiable, IServiceSuspeito
    {
        private readonly IRepositorySuspeito _repository;

        public ServiceSuspeito() { }

        public ServiceSuspeito(IRepositorySuspeito repository)
        {
            _repository = repository;
        }

        public AdicionarSuspeitoResponse Adicionar(AdicionarSuspeitoRequest request)
        {
            var nome = request.Nome;

            var suspeito = new Suspeito(nome);

            if (_repository.Existe(x => x.Nome == suspeito.Nome))
            {
                AddNotification("Nome", Message.JA_EXISTE_UM_X0_CHAMADO_X1.ToFormat("suspeito", suspeito.Nome));
            }

            if (IsInvalid())
            {
                return null;
            }

            suspeito = _repository.Adicionar(suspeito);

            return (AdicionarSuspeitoResponse)suspeito;
        }

        public AlterarSuspeitoResponse Alterar(AlterarSuspeitoRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarSuspeitoRequest", Message.X0_E_OBRIGATORIO.ToFormat("AlterarSuspeitoRequest"));
            }

            var suspeito = _repository.ObterPorId(request.Id);

            if (suspeito == null)
            {
                AddNotification("Suspeito", Message.X0_NAO_ENCONTRADO.ToFormat("Suspeito"));
                return null;
            }

            suspeito.Alterar(request.Nome);

            _repository.Editar(suspeito);

            return (AlterarSuspeitoResponse)suspeito;
        }

        public ResponseBase Excluir(int id)
        {
            var suspeito = _repository.ObterPorId(id);

            if (suspeito == null)
            {
                AddNotification("Suspeito", Message.X0_NAO_ENCONTRADO.ToFormat("Suspeito"));
                return null;
            }

            _repository.Remover(suspeito);

            return new ResponseBase();
        }

        public IEnumerable<SuspeitoResponse> Listar()
        {
            return _repository.Listar().ToList().Select(suspeito => (SuspeitoResponse)suspeito).ToList();
        }

        public SuspeitoResponse ObterRandomico()
        {
            var suspeito = _repository.Listar().OrderBy(r => Guid.NewGuid()).Take(1).First();

            return (SuspeitoResponse)suspeito;
        }
    }
}
