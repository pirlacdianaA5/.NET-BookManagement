using Application.Use_Cases.Commands;
using Application.Utils.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers
{
    public class UpdateBookCommandHandlers : IRequestHandler<UpdateBookCommand, Result>
    {
        private IBookRepository repository;

        public UpdateBookCommandHandlers(IBookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await repository.GetByIdAsync(request.Id);
            if (book == null)
            {
                return Result.Failure();
            }
            book.Title = request.Title;
            book.Author = request.Author;
            book.ISBN = request.ISBN;
            book.PublicationDate = request.PublicationDate;
            await repository.UpdateAsync(book);
            return Result.Success();
        }
    }
}
