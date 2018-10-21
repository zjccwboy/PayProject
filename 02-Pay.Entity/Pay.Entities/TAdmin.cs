using System;

namespace Pay.Entities
{
    public partial class TAdmin : BaseEntity
    {
        [Key]
        public long AccountId { get; set; }
        public int JobNumber { get; set; }
        public string FirstLoginIp { get; set; }
        public string LastLoginIp { get; set; }
        public DateTime? FirstLoginTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
