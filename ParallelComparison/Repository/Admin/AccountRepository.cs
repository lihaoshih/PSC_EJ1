using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ParallelComparison.Models.Admin;
using DataAccess.Services;
using DataAccess.Models;

namespace ParallelComparison.Repository.Admin
{
    public class AccountRepository : DapperBase, IAccountRepository<AccountModel>
    {
        private readonly IConfiguration _configuration;
        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<AccountModel>> GetAllAsync()
        {
            string sqlCommand = "Select * from dbo.Ctrl_Users";

            DapperConnectModel connect = new DapperConnectModel()
            {
                SqlConnectionString = "EPB_CEMS",
                SqlCommandModel = new SqlCommandModel()
                {
                    SqlCommand = sqlCommand,
                    isStoredProcedure = false
                },
                SqlParameter = null
            };

            return await QueryAsync<AccountModel>(connect);
        }

        public async Task<AccountModel> GetByUserNameAsync(string userName)
        {
            string sqlCommand = "Select * from dbo.Ctrl_Users where UserName = @userName";

            DynamicParameters param = new DynamicParameters();
            param.Add("@userName", userName);

            DapperConnectModel connect = new DapperConnectModel()
            {
                SqlConnectionString = "EPB_CEMS",
                SqlCommandModel = new SqlCommandModel()
                {
                    SqlCommand = sqlCommand,
                    isStoredProcedure = false
                },
                SqlParameter = param
            };

            return await QueryFirstOrDefaultAsync<AccountModel>(connect);
        }
    }
}
