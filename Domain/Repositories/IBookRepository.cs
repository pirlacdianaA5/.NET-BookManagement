using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBookRepository
    {
        //in infrastructure va fi implementarea concreta a interfetei
        Task<IEnumerable<Book>> GetAllAsync(); //vreau sa lucrez cu paradigma sync await
        Task<Book> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Book book); // cand creez o carte intorc doar id ul !
        Task UpdateAsync(Book book);
        Task DeleteAsync(Guid id);
    }
}
