
namespace Pay.Entities
{
    public partial class TDfOrder : BaseEntity
    {
        [Key]
        public long OrderNum { get; set; }
        public string Mnum { get; set; }
        public int Mid { get; set; }
        public string FromIp { get; set; }
        public int ChannelType { get; set; }
        public string ChannelCode { get; set; }
        public decimal Amount { get; set; }
        public int State { get; set; }
        public string NotifyUrl { get; set; }
    }
}
