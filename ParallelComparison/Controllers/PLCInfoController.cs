using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParallelComparison.Models.PLCInfoData;
using ParallelComparison.Repository;
using Syncfusion.EJ2.QueryBuilder;
using Newtonsoft.Json;
using ParallelComparison.Repository.PLCInfo;
using Syncfusion.EJ2.Base;

namespace ParallelComparison.Controllers
{
	public class PLCInfoController : Controller
	{
		private readonly IPLCInfoRepository _pLCInfoRepo;
        public PLCInfoController(IPLCInfoRepository pLCInfoRepo)
        {
			_pLCInfoRepo = pLCInfoRepo;
        }

		public IActionResult UrlDataSource([FromBody]DataManagerRequest dm)
		{
			IEnumerable<PLCInfoModel> DataSource = _pLCInfoRepo.GetAll();
			DataOperations operation = new DataOperations();

			if (dm.Search != null && dm.Search.Count > 0)
				DataSource = operation.PerformSearching(DataSource, dm.Search);
			if (dm.Sorted != null && dm.Sorted.Count > 0)
				DataSource = operation.PerformSorting(DataSource, dm.Sorted);
			if (dm.Where != null && dm.Where.Count > 0)
				DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);

			int count = DataSource.Cast<PLCInfoModel>().Count();

			if (dm.Skip != 0)
				DataSource = operation.PerformSkip(DataSource, dm.Skip);

			if (dm.Take != 0)
				DataSource = operation.PerformTake(DataSource, dm.Take);

			return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
		}

		//GET
		public IActionResult PLCInfoList()
		{
			ViewBag.datasource = _pLCInfoRepo.GetAll();
			return View();
		}
	}
}
