using System;
using System.ComponentModel.DataAnnotations;

namespace ParallelComparison.Models.PLCInfoData
{
    public class PLCInfoModel : BaseEntity
    {
		/// <summary>
		/// 污染源編號（管制編號+管道編號）
		/// </summary>
		[Display(Name = "污染源編號")]
		[Key]
		public string PipeNo { get; }

		/// <summary>
		/// 管制編號
		/// </summary>
		[Display(Name = "管制編號")]
		public string CNO { get; set; }

		/// <summary>
		/// 排放管道編號
		/// </summary>
		[Display(Name = "管道編號")]
		public string PolNo { get; set; }

		/// <summary>
		/// 訊號輸入種類 1:0~5V; 2:0~10V; 3:4~20mA
		/// </summary>
		[Display(Name = "訊號種類")]
		public byte SignalType { get; set; }

		/// <summary>
		/// PLC廠牌
		/// </summary>
		[Display(Name = "PLC廠牌")]
		public string PLCBrand { get; set; }

		/// <summary>
		/// PLC型號
		/// </summary>
		[Display(Name = "PLC型號")]
		public string PLCModel { get; set; }

		/// <summary>
		/// 自行組裝
		/// </summary>
		[Display(Name = "自行組裝")]
		public bool SelfAssembly { get; set; }

		/// <summary>
		/// PLC序號
		/// </summary>
		[Display(Name = "PLC序號")]
		public string PLCSerial { get; set; }
	}
}
