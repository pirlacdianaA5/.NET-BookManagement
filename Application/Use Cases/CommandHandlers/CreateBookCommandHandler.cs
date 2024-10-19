using Application.Use_Cases.Commands;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        // (Dependency Injection?) nu am injectat implemetarea concreta a repository ului
        private readonly IBookRepository repository;  //acest field este o singura data initializat si ramane cu acea valoare pana e sters de garbage collector
        public CreateBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;

        }

        //implementare implicita a metodei din interfata IRequestHandler
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken) // ne ajuta la oprirea executiei unui task
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                PublicationDate = request.PublicationDate
            };
            return await repository.AddAsync(book); //dc o folosesc await aici ? pt ca vreau sa astept sa se termine operatia de adaugare a cartii in repository si nu vr sa se blocheze executia !
        }
    }
}
