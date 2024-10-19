using Application.DTOs;
using Application.Utils.Shared;
using MediatR;

namespace Application.Use_Cases.Queries
{
    public class GetBookByIdQuery : IRequest<Result<BookDto>>
    {

        public Guid Id { get; set; }
    }
}
