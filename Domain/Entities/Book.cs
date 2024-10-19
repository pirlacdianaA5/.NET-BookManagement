namespace Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; } // This is the primary key
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
