using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ParallelComparison.Models.PLCInfoData;
using DataAccess.Services;
using DataAccess.Models;

namespace ParallelComparison.Repository.PLCInfo
{
	public class PLCInfoRepository : DapperBase, IPLCInfoRepository
	{
		private readonly IConfiguration _configuration;
		public PLCInfoRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// 呼叫SP_PLCInfo，取得PLCInfo資料
		/// </summary>
		/// <returns></returns>
		public async Task<List<PLCInfoModel>> GetAllAsync()
		{

			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "A");

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = this._configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			return await QueryAsync<PLCInfoModel>(connect);
		
		}

		public List<PLCInfoModel> GetAll()
		{
			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "A");

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = this._configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			return Query<PLCInfoModel>(connect);

		}

		/// <summary>
		/// 新增、更新plc資料
		/// </summary>
		/// <param name="pLCInfo"></param>
		/// <returns></returns>

		/// <summary>
		/// 取得單一個污染源的plc資訊
		/// </summary>
		/// <param name="strPipeNo"></param>
		/// <returns></returns>
		public async Task<PLCInfoModel> GetByIdAsync(PLCInfoModel pLCInfoModel)
		{
			string strCNO, strPolNo;

			strCNO = pLCInfoModel.CNO;
			strPolNo = pLCInfoModel.PolNo;

			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "G");
			param.Add("@CNO", strCNO);
			param.Add("@PolNo", strPolNo);

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = _configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			return await QuerySingleAsync<PLCInfoModel>(connect);
		}

		public PLCInfoModel GetById(PLCInfoModel pLCInfoModel)
		{
			string strCNO, strPolNo;

			strCNO = pLCInfoModel.CNO;
			strPolNo = pLCInfoModel.PolNo;

			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "G");
			param.Add("@CNO", strCNO);
			param.Add("@PolNo", strPolNo);

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = _configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			return QuerySingle<PLCInfoModel>(connect);
		}


		public async Task CreateAsync(PLCInfoModel pLCInfoModel)
		{
			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "U");
			param.Add("@CNO", pLCInfoModel.CNO);
			param.Add("@PolNo", pLCInfoModel.PolNo);
			param.Add("@SignalType", pLCInfoModel.SignalType);
			param.Add("@PLCBrand", pLCInfoModel.PLCBrand);
			param.Add("@PLCModel", pLCInfoModel.PLCModel);
			param.Add("@SelfAssembly", pLCInfoModel.SelfAssembly);
			param.Add("@PLCSerial", pLCInfoModel.PLCSerial);

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = _configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			await ExecuteAsync(connect);
		}

		public void Create(PLCInfoModel pLCInfoModel)
		{
			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "U");
			param.Add("@CNO", pLCInfoModel.CNO);
			param.Add("@PolNo", pLCInfoModel.PolNo);
			param.Add("@SignalType", pLCInfoModel.SignalType);
			param.Add("@PLCBrand", pLCInfoModel.PLCBrand);
			param.Add("@PLCModel", pLCInfoModel.PLCModel);
			param.Add("@SelfAssembly", pLCInfoModel.SelfAssembly);
			param.Add("@PLCSerial", pLCInfoModel.PLCSerial);

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = _configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			Execute(connect);
		}


		public async Task UpdateAsync(PLCInfoModel pLCInfoModel)
		{
			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "U");
			param.Add("@CNO", pLCInfoModel.CNO);
			param.Add("@PolNo", pLCInfoModel.PolNo);
			param.Add("@SignalType", pLCInfoModel.SignalType);
			param.Add("@PLCBrand", pLCInfoModel.PLCBrand);
			param.Add("@PLCModel", pLCInfoModel.PLCModel);
			param.Add("@SelfAssembly", pLCInfoModel.SelfAssembly);
			param.Add("@PLCSerial", pLCInfoModel.PLCSerial);

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = _configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			await ExecuteAsync(connect);
		}

		public void Update(PLCInfoModel pLCInfoModel)
		{
			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "U");
			param.Add("@CNO", pLCInfoModel.CNO);
			param.Add("@PolNo", pLCInfoModel.PolNo);
			param.Add("@SignalType", pLCInfoModel.SignalType);
			param.Add("@PLCBrand", pLCInfoModel.PLCBrand);
			param.Add("@PLCModel", pLCInfoModel.PLCModel);
			param.Add("@SelfAssembly", pLCInfoModel.SelfAssembly);
			param.Add("@PLCSerial", pLCInfoModel.PLCSerial);

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = _configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			Execute(connect);
		}


		public async Task DeleteAsync(string strPipeNo)
		{
			string strCNO, strPolNo;

			strCNO = strPipeNo.Substring(0, 8);
			strPolNo = strPipeNo.Substring(8, 4);

			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "D");
			param.Add("@CNO", strCNO);
			param.Add("@PolNo", strPolNo);

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = _configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			await ExecuteAsync(connect);
		}

		public void Delete(string strPipeNo)
		{
			string strCNO, strPolNo;

			strCNO = strPipeNo.Substring(0, 8);
			strPolNo = strPipeNo.Substring(8, 4);

			DynamicParameters param = new DynamicParameters();
			param.Add("@MODE", "D");
			param.Add("@CNO", strCNO);
			param.Add("@PolNo", strPolNo);

			DapperConnectModel connect = new DapperConnectModel()
			{
				SqlConnectionString = _configuration.GetConnectionString("PSCAudit"),
				SqlParameter = param
			};

			connect.SqlCommandModel = new SqlCommandModel()
			{
				SqlCommand = "dbo.SP_PLCInfo",
				isStoredProcedure = true
			};

			Execute(connect);
		}

	}
}
