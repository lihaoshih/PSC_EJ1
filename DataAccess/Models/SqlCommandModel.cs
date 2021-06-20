using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class SqlCommandModel
    {
        public string SqlCommand { get; set; }

        public bool isStoredProcedure { get; set; }
    }
}
