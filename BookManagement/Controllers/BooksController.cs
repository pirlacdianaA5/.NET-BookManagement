using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using Application.Utils.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //CREATE
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] CreateBookCommand command)
        {
            return await mediator.Send(command);
        }


        //GET BY ID
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            var query = new GetBookByIdQuery { Id = id };
            Result<BookDto> result = await mediator.Send(query);
            if (result.IsFailure)
            {
                return NotFound(new { message = "Book with this id was not found.Try another id!" });
            }
            return Ok(result.Value);
        }


        //GET ALL
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks()
        {
            return await mediator.Send(new GetAllBooksQuery());
        }

        //DELETE
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteBookCommand { Id = id };
            Result result = await mediator.Send(command);
            if (result.IsFailure)
            {
                return NotFound(new { message = "Book with this id was not found.Try another id!" });
            }
            return NoContent();
        }

        //UPDATE
        [HttpPost("{id:guid}")]
        public async Task<ActionResult> UpdateBook(Guid id, [FromBody] UpdateBookCommand command)
        {
            Result result = await mediator.Send(command);
            if (result.IsFailure)
            {
                return NotFound(new { message = "Book with this id was not found.Try another id!" });
            }
            return NoContent();
        }
    }
}
