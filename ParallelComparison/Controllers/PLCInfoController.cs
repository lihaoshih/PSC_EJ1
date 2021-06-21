using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParallelComparison.Models.PLCInfoData;
using ParallelComparison.Repository.PLCInfo;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.Linq;
using Syncfusion.JavaScript;

namespace ParallelComparison.Controllers
{
	public class PLCInfoController : Controller
	{
		private readonly IPLCInfoRepository _pLCInfoRepo;

		public static List<PLCInfoModel> plcdata = new List<PLCInfoModel>();
		public PLCInfoController(IPLCInfoRepository pLCInfoRepo)
		{
			_pLCInfoRepo = pLCInfoRepo;
		}

		public IActionResult UrlDataSource([FromBody] DataManager dm)
		{
			IEnumerable<PLCInfoModel> DataSource = plcdata;
			DataOperations operation = new DataOperations();

			if (dm.Search != null && dm.Search.Count > 0)
				DataSource = operation.PerformSearching(DataSource, dm.Search);
			if (dm.Sorted != null && dm.Sorted.Count > 0)
				DataSource = operation.PerformSorting(DataSource, dm.Sorted);
			if (dm.Where != null && dm.Where.Count > 0)
				DataSource = operation.PerformWhereFilter(DataSource, dm.Where, dm.Where[0].Operator);

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
			plcdata = _pLCInfoRepo.GetAll();
			ViewBag.datasource = plcdata;
			return View();
		}

		public IActionResult Insert([FromBody]CRUDModel<PLCInfoModel> model)
		{
			_pLCInfoRepo.Create(model.Value);
			plcdata = _pLCInfoRepo.GetAll();
			return Json(plcdata);
		}

		public IActionResult Update([FromBody]CRUDModel<PLCInfoModel> model)
		{
			_pLCInfoRepo.Update(model.Value);
			plcdata = _pLCInfoRepo.GetAll();
			return Json(plcdata);
		}

		public IActionResult Remove([FromBody]CRUDModel<PLCInfoModel> model)
		{
			var key = model.Key.ToString();
			_pLCInfoRepo.Delete(key);
			plcdata = _pLCInfoRepo.GetAll();
			return Json(plcdata);
		}


	}
}
