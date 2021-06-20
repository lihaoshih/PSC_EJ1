using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class DapperBase
    {
        public void Execute(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        databaseConnection.Execute(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                    else
                        databaseConnection.Execute(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
      
        public async Task ExecuteAsync(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        await databaseConnection.ExecuteAsync(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                    else
                        await databaseConnection.ExecuteAsync(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<T> Query<T>(DapperConnectModel model)
        {
            try {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        return databaseConnection.Query<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure).ToList();
                    else
                        return databaseConnection.Query<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<List<T>> QueryAsync<T>(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                    {
                        var test = await databaseConnection.QueryAsync<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                        return test.ToList();
                    }
                    else
                    {
                        var test = await databaseConnection.QueryAsync<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                        return test.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public T QueryFirstOrDefault<T>(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        return databaseConnection.QueryFirstOrDefault<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                    else
                        return databaseConnection.QueryFirstOrDefault<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        return await databaseConnection.QueryFirstOrDefaultAsync<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                    else
                        return await databaseConnection.QueryFirstOrDefaultAsync<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public T QuerySingle<T>(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        return databaseConnection.QuerySingle<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                    else
                        return databaseConnection.QuerySingle<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<T> QuerySingleAsync<T>(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        return await databaseConnection.QuerySingleAsync<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                    else
                        return await databaseConnection.QuerySingleAsync<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public T QuerySingleOrDefault<T>(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        return databaseConnection.QuerySingleOrDefault<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                    else
                        return databaseConnection.QuerySingleOrDefault<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                }
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(DapperConnectModel model)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(model.SqlConnectionString))
                {
                    if (model.SqlCommandModel.isStoredProcedure)
                        return await databaseConnection.QuerySingleOrDefaultAsync<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter, commandType: CommandType.StoredProcedure);
                    else
                        return await databaseConnection.QuerySingleOrDefaultAsync<T>(model.SqlCommandModel.SqlCommand, model.SqlParameter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
