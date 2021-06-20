using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ParallelComparison.Models
{
    public class PSCAuditModel
    {   
        /// <summary>
        /// 平行比對測試編號
        /// </summary>
        [Display(Name = "測試編號")]
        public string PSCID { get; set; }

        /// <summary>
        /// 受測管制編號
        /// </summary>
        [Display(Name = "管制編號")]
        public string AuditeeCNO { get; set; }

        /// <summary>
        /// 受測排放管道編號
        /// </summary>
        [Display(Name = "排放管道編號")]
        public string AuditeePolNO { get; set; }


        /// <summary>
        /// 是否符合電路配置─0：不符合；1：符合
        /// </summary>
        [Display(Name = "電路配置")]
        public bool CircuitDesign { get; set; }

        /// <summary>
        /// 測試開始日期時間
        /// </summary>
        [Display(Name = "測試開始時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? AuditBegin { get; set; }

        /// <summary>
        /// 測試結束日期時間
        /// </summary>
        [Display(Name = "測試結束時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? AuditEnd { get; set; }
        
        /// <summary>
        /// 受測監測項目
        /// </summary>
        public List<string> AuditItems { get; set; }
    }
}
