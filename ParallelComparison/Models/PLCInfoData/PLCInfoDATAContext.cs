using Microsoft.EntityFrameworkCore;

namespace ParallelComparison.Models.PLCInfoData
{
    public partial class PLCInfoDATAContext : DbContext
    {
        public PLCInfoDATAContext()
        {
        }

        public PLCInfoDATAContext(DbContextOptions<PLCInfoDATAContext> options) : base(options)
        {
        }

        public virtual DbSet<PLCInfoModel> PLCInfoModel { get; set; }
        public virtual DbSet<PLCAquiringSettingModel> PLCAcquiringSettingModel { get; set; }
    }
}
