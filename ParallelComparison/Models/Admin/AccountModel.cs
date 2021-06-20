using System;

namespace ParallelComparison.Models.Admin
{
    public partial class AccountModel : BaseEntity
    {
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string DepID { get; set; }

        public string CompID { get; set; }
    }
}
