﻿namespace Application.DTOs
{
    //DATA TRANSFER OBJECT  -> nu expune spre exterior entitatile din domeniu
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

