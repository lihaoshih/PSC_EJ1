using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class DapperConnectModel
    {
        public string SqlConnectionString { get; set; }

        public SqlCommandModel SqlCommandModel { get; set; }

        public object SqlParameter { get; set; } = null;
    }
}
