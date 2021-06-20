using ParallelComparison.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelComparison.Repository.Admin
{
    public interface IAccountRepository<AccountModel>
    {
        Task<List<AccountModel>> GetAllAsync();
        Task<AccountModel> GetByUserNameAsync(string userName);
    }
}
