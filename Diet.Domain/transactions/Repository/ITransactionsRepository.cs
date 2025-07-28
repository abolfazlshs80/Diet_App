using Diet.Framework.Core.Interface;
namespace Diet.Domain.transactions.Repository
{
    public interface ITransactionsRepository : IRepository
    {
        Task<List<Diet.Domain.transactions.Transactions>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.transactions.Transactions> ByIdAsync(Guid id);

        Task AddAsync(Diet.Domain.transactions.Transactions transactions);
        Task UpdateAsync(Diet.Domain.transactions.Transactions transactions);
        Task DeleteAsync(Diet.Domain.transactions.Transactions transactions);
    }
}
