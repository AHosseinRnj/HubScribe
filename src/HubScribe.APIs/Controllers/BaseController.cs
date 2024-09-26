using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HubScribe.APIs.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    #region [ Fields ]  
    protected readonly IMediator _mediator;
    #endregion

    #region [ Constructor ]
    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    #endregion
}