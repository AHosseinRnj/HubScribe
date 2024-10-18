using MediatR;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace HubScribe.APIs.Controllers.V1;

[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ArticleController : BaseController
{
    #region [ Constructor ]
    public ArticleController(IMediator mediator) : base(mediator) { }
    #endregion
}