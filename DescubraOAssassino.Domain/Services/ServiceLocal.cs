using DescubraOAssassino.Domain.Arguments.Base;
using DescubraOAssassino.Domain.Arguments.Local;
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
    public class ServiceLocal : Notifiable, IServiceLocal
    {
        private readonly IRepositoryLocal _repository;

        public ServiceLocal() { }

        public ServiceLocal(IRepositoryLocal repository)
        {
            _repository = repository;
        }

        public AdicionarLocalResponse Adicionar(AdicionarLocalRequest request)
        {
            var nome = request.Nome;

            var local = new Local(nome);

            if (_repository.Existe(x => x.Nome == local.Nome))
            {
                AddNotification("Nome", Message.JA_EXISTE_UM_X0_CHAMADO_X1.ToFormat("local", local.Nome));
            }

            if (IsInvalid())
            {
                return null;
            }

            local = _repository.Adicionar(local);

            return (AdicionarLocalResponse)local;
        }

        public AlterarLocalResponse Alterar(AlterarLocalRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarLocalRequest", Message.X0_E_OBRIGATORIO.ToFormat("AlterarLocalRequest"));
            }

            var local = _repository.ObterPorId(request.Id);

            if (local == null)
            {
                AddNotification("Suspeito", Message.X0_NAO_ENCONTRADO.ToFormat("Local"));
                return null;
            }

            local.Alterar(request.Nome);

            _repository.Editar(local);

            return (AlterarLocalResponse)local;
        }

        public ResponseBase Excluir(int id)
        {
            var local = _repository.ObterPorId(id);

            if (local == null)
            {
                AddNotification("Local", Message.X0_NAO_ENCONTRADO.ToFormat("Local"));
                return null;
            }

            _repository.Remover(local);

            return new ResponseBase();
        }

        public IEnumerable<LocalResponse> Listar()
        {
            return _repository.Listar().ToList().Select(local => (LocalResponse)local).ToList();
        }

        public LocalResponse ObterRandomico()
        {
            var local = _repository.Listar().OrderBy(r => Guid.NewGuid()).Take(1).First();

            return (LocalResponse)local;
        }
    }
}
