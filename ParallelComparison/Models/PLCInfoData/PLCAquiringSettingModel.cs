using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParallelComparison.Models.PLCInfoData
{
	public class PLCAquiringSettingModel
	{
		/// <summary>
		/// 管制編號
		/// </summary>
		[Display(Name = "管制編號")]
		public string CNO  { get; set; }

		/// <summary>
		/// 排放管道編號
		/// </summary>
		[Display(Name = "排放管道編號")]
		public string PolNO { get; set; }

		/// <summary>
		/// 監測項目種類─1：OP；2：氣狀污染物；3：稀釋氣體；4：排放流率；5：VOCs
		/// </summary>
		[Display(Name = "監測項目")]
		public char ItemType { get; set; }

		/// <summary>
		/// 擷取頻率種類─1：法定頻率；0：核定
		/// </summary>
		[Display(Name = "擷取頻率種類")]
		public bool AssignedFreq { get; set; }

		/// <summary>
		/// 擷取頻率
		/// </summary>
		[Display(Name = "擷取頻率")]
		public string Freq { get; set; }

		/// <summary>
		/// 擷取時間設定
		/// </summary>
		[Display(Name = "擷取時間")]
		public List<int> AcquiringTime { get; set; }
		
		/// <summary>
		/// 擷取時間誤差
		/// </summary>
		[Display(Name = "擷取時間誤差")]
		public int Bias { get; set; }
	}
}
