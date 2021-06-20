using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ParallelComparison.Repository
{
	public abstract class BaseRepository
	{
		private readonly IConfiguration _configuration;

		public BaseRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected IDbConnection CreateDbConnection()
		{
			return new SqlConnection(_configuration.GetConnectionString("EPB_CEMS"));
		}
	}
}
