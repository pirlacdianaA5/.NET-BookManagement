using Application.Utils.Shared;
using MediatR;

namespace Application.Use_Cases.Commands
{
    public class DeleteBookCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
