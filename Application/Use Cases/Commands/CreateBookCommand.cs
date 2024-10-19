using MediatR;

namespace Application.Use_Cases.Commands
{
    public class CreateBookCommand : IRequest<Guid> //asta e ceea ce va intoarce aceasta clasa ca rezultat
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
