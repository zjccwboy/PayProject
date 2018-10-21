
namespace Pay.Entities
{
    public partial class TFailureOrder : BaseEntity
    {
        [Key]
        public long OrderNum { get; set; }
        public string Mnum { get; set; }
        public int Fmid { get; set; }
        public string FromIp { get; set; }
        public int ChannelType { get; set; }
        public string ChannelCode { get; set; }
        public decimal Amount { get; set; }
    }
}
