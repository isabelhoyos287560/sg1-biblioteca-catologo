using Library.Application.Common;
using Library.Application.UseCases.Books.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllBooksQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBookByIdQuery(id), cancellationToken);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("category/{categoryId:guid}")]
        public async Task<IActionResult> GetByCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBooksByCategoryQuery(categoryId), cancellationToken);
            return Ok(result);
        }
    }
}