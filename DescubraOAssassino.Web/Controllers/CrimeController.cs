using DescubraOAssassino.Domain.Arguments.Jogo;
using DescubraOAssassino.Domain.Entities;
using DescubraOAssassino.Domain.Inferfaces.Services;
using DescubraOAssassino.Infra.Transactions;
using DescubraOAssassino.Web.Controllers.Base;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace DescubraOAssassino.Web.Controllers
{
    [RoutePrefix("api/crime")]
    public class CrimeController : ApiControllerBase
    {
        private readonly IServiceSuspeito _serviceSuspeito;
        private readonly IServiceArma _serviceArma;
        private readonly IServiceLocal _serviceLocal;
        private readonly IServiceCrime _serviceCrime;

        public CrimeController(IUnitOfWork unitOfWork, IServiceSuspeito serviceSuspeito, IServiceArma serviceArma, IServiceLocal serviceLocal, IServiceCrime serviceCrime) : base(unitOfWork)
        {
            _serviceSuspeito = serviceSuspeito;
            _serviceLocal = serviceLocal;
            _serviceArma = serviceArma;
            _serviceCrime = serviceCrime;
        }

        [Route("suspeitos")]
        [HttpGet]
        public async Task<HttpResponseMessage> Suspeitos()
        {
            try
            {
                var response = _serviceSuspeito.Listar();

                return await ResponseAsync(response, _serviceSuspeito);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("armas")]
        [HttpGet]
        public async Task<HttpResponseMessage> Armas()
        {
            try
            {
                var response = _serviceArma.Listar();

                return await ResponseAsync(response, _serviceArma);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("locais")]
        [HttpGet]
        public async Task<HttpResponseMessage> Locais()
        {
            try
            {
                var response = _serviceLocal.Listar();

                return await ResponseAsync(response, _serviceLocal);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("all")]
        [HttpGet]
        public async Task<HttpResponseMessage> All()
        {
            try
            {
                var responseArma = _serviceArma.Listar();
                var responseSuspeito = _serviceSuspeito.Listar();
                var responseLocal = _serviceLocal.Listar();

                var response = new AllResponse(responseArma, responseLocal, responseSuspeito);

                return await ResponseAsync(response, _serviceLocal);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("new")]
        [HttpGet]
        public async Task<HttpResponseMessage> New()
        {
            try
            {
                var responseArma = _serviceArma.ObterRandomico();
                var responseSuspeito = _serviceSuspeito.ObterRandomico();
                var responseLocal = _serviceLocal.ObterRandomico();

                var request = new AdicionarCrimeRequest(responseSuspeito, responseArma, responseLocal);
                var response = _serviceCrime.Adicionar(request);
                return await ResponseAsync(response, _serviceCrime);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("check")]
        [HttpGet]
        public async Task<HttpResponseMessage> Check(Guid id, int suspeito, int local, int arma)
        {
            try
            {
                _serviceCrime.RemoveExpirad();
                var crime = (Crime)_serviceCrime.ObterPorId(id);
                var requestTeoria = new TeoriaRequest(suspeito, local, arma);
                var responseTeoria = new TeoriaResponse(crime.ChecarTeoria(requestTeoria));
                
                return await ResponseAsync(responseTeoria, _serviceCrime);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
