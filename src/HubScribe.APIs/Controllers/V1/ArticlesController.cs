using MediatR;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using HubScribe.Application.Features.Commands.Articles.CreateArticle;

namespace HubScribe.APIs.Controllers.V1;

[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ArticlesController : BaseController
{
    #region [ Constructor ]
    public ArticlesController(IMediator mediator) : base(mediator) { }
    #endregion

    #region [ Article ]
    [HttpPost]
    public async Task<IActionResult> CreateArticle([FromBody] CreateArticleCommand command, CancellationToken cancellationToken)
    {
        var articleId = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetArticleById), new { id = articleId }, articleId);
    }

    [HttpGet("{id}")]
    public IActionResult GetArticleById(Guid id)
    {
        return Ok();
    }
    #endregion
}