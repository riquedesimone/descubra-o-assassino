using System;
using System.Collections.Generic;
using System.Linq;
using DescubraOAssassino.Domain.Arguments.Arma;
using DescubraOAssassino.Domain.Arguments.Base;
using DescubraOAssassino.Domain.Entities;
using DescubraOAssassino.Domain.Inferfaces.Repositories;
using DescubraOAssassino.Domain.Inferfaces.Services;
using DescubraOAssassino.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace DescubraOAssassino.Domain.Services
{
    public class ServiceArma : Notifiable, IServiceArma
    {
        private readonly IRepositoryArma _repository;

        public ServiceArma() { }

        public ServiceArma(IRepositoryArma repository)
        {
            _repository = repository;
        }

        public AdicionarArmaResponse Adicionar(AdicionarArmaRequest request)
        {
            var nome = request.Nome;

            var arma = new Arma(nome);

            if(_repository.Existe( x => x.Nome == arma.Nome))
            {
                AddNotification("Nome", Message.JA_EXISTE_UMA_X0_CHAMADA_X1.ToFormat("arma", arma.Nome));
            }

            if(IsInvalid())
            {
                return null;
            }

            arma = _repository.Adicionar(arma);

            return (AdicionarArmaResponse)arma;
        }

        public AlterarArmaResponse Alterar(AlterarArmaRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarArmaRequest", Message.X0_E_OBRIGATORIO.ToFormat("AlterarArmaRequest"));
            }

            var arma = _repository.ObterPorId(request.Id);

            if(arma == null)
            {
                AddNotification("Arma", Message.X0_NAO_ENCONTRADA.ToFormat("Arma"));
                return null;
            }

            arma.Alterar(request.Nome);

            _repository.Editar(arma);

            return (AlterarArmaResponse)arma;
        }

        public ResponseBase Excluir(int id)
        {
            var arma = _repository.ObterPorId(id);

            if (arma == null)
            {
                AddNotification("Arma", Message.X0_NAO_ENCONTRADA.ToFormat("Arma"));
                return null;
            }

            _repository.Remover(arma);

            return new ResponseBase();
        }

        public IEnumerable<ArmaResponse> Listar()
        {
            return _repository.Listar().ToList().Select(arma => (ArmaResponse)arma).ToList();
        }

        public ArmaResponse ObterRandomico()
        {
            var arma = _repository.Listar().OrderBy(r => Guid.NewGuid()).Take(1).First();

            return (ArmaResponse)arma;
        }
    }
}
