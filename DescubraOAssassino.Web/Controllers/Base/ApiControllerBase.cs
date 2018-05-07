using DescubraOAssassino.Domain.Inferfaces.Services.Base;
using DescubraOAssassino.Infra.Transactions;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DescubraOAssassino.Web.Controllers.Base
{
  public class ApiControllerBase : ApiController
  {
    private readonly IUnitOfWork _unitOfWork;
    private IServiceBase _serviceBase;

    public ApiControllerBase(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<HttpResponseMessage> ResponseAsync(object result, IServiceBase serviceBase)
    {
      _serviceBase = serviceBase;

      if (!serviceBase.Notifications.Any())
      {
        try
        {
          _unitOfWork.Commit();

          return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        catch (Exception ex)
        {
          return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
        }
      }
      else
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = serviceBase.Notifications });
      }
    }

    public async Task<HttpResponseMessage> ResponseExceptionAsync(Exception ex)
    {
      return Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });
    }

    protected override void Dispose(bool disposing)
    {
      if (_serviceBase != null)
      {
        _serviceBase.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}