using Application.Use_Cases.Commands;
using Application.Utils.Shared;
using Domain.Repositories;
using MediatR;


namespace Application.Use_Cases.CommandHandlers
{
    public class DeleteBookCommandHandlers : IRequestHandler<DeleteBookCommand, Result>
    {
        private readonly IBookRepository repository;

        public DeleteBookCommandHandlers(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await repository.GetByIdAsync(request.Id);
            if (book == null)
            {
                return Result.Failure();
            }
            await repository.DeleteAsync(request.Id);
            return Result.Success();
        }

    }
}
