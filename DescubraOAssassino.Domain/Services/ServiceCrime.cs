using DescubraOAssassino.Domain.Arguments.Arma;
using DescubraOAssassino.Domain.Arguments.Base;
using DescubraOAssassino.Domain.Arguments.Jogo;
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
    public class ServiceCrime : Notifiable, IServiceCrime
    {
        private readonly IRepositoryCrime _repository;

        public ServiceCrime() { }

        public ServiceCrime(IRepositoryCrime repository)
        {
            _repository = repository;
        }

        public AdicionarCrimeResponse Adicionar(AdicionarCrimeRequest request)
        {
            var crime = new Crime((Suspeito)request.Suspeito, (Local)request.Local, (Arma)request.Arma);
            _repository.Adicionar(crime);
            _repository.SaveChanges();
            return (AdicionarCrimeResponse)crime;
        }

        public CrimeResponse ObterPorId(Guid id)
        {
            return (CrimeResponse)_repository.ObterPorId(id);
        }

        public void RemoveExpirad()
        {
            var expireds = _repository.ListarPor(x => x.ExpireDate <= DateTime.Now).ToList();

            expireds.ForEach(x => _repository.Remover(x));
            _repository.SaveChanges();
        }
    }
}
