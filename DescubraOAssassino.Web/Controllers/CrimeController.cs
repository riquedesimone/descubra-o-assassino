using DescubraOAssassino.Domain.Inferfaces.Services;
using DescubraOAssassino.Infra.Transactions;
using DescubraOAssassino.Web.Controllers.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DescubraOAssassino.Web.Controllers
{
  [RoutePrefix("api/crime")]
  public class CrimeController : ApiControllerBase
  {
    private readonly IServiceSuspeito _serviceSuspeito;
    private readonly IServiceArma _serviceArma;
    private readonly IServiceLocal _serviceLocal;
    
    public CrimeController(IUnitOfWork unitOfWork, IServiceSuspeito serviceSuspeito, IServiceArma serviceArma, IServiceLocal serviceLocal) : base(unitOfWork)
    {
      _serviceSuspeito = serviceSuspeito;
      _serviceLocal = serviceLocal;
      _serviceArma = serviceArma;
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

  }
}
