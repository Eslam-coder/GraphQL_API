using Microsoft.EntityFrameworkCore;
using Project_GraphQL_Web_API_Practice.Contracts;
using Project_GraphQL_Web_API_Practice.Entities;
using Project_GraphQL_Web_API_Practice.Entities.Context;

namespace Project_GraphQL_Web_API_Practice.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId) 
        {
            return  _context.Accounts
                    .Where(account => account.Owner.Id.Equals(ownerId))
                    .ToList();
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts
                                         .Where(a => ownerIds.Contains(a.Owner.Id))
                                         .ToListAsync();
            return accounts.ToLookup(a => a.Owner.Id);
        }
    }
}
