using Diet.Domain.Contract.DTOs.Transactions;
using Diet.Framework.Core.Interface;
namespace Diet.Domain.transactions.Repository
{
    public interface ITransactionsRepository : IRepository
    {
        Task<List<GetItemTransactionsDto>> AllAsync(string? searchText, int pageCount = 8, int pageNumber = 0);
        Task<Diet.Domain.transactions.Transactions> ByIdAsync(Guid id);
        Task<GetItemTransactionsDto> ByIdDtoAsync(Guid id);
        Task<bool> IsExists(Guid id);
        Task AddAsync(Diet.Domain.transactions.Transactions transactions);
        void Update(Diet.Domain.transactions.Transactions transactions);
        void Delete(Diet.Domain.transactions.Transactions transactions);
    }
}
