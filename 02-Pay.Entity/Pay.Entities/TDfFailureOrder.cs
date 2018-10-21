
namespace Pay.Entities
{
    public partial class TDfFailureOrder : BaseEntity
    {
        [Key]
        public long OrderNum { get; set; }
        public string Mnum { get; set; }
        public int Mid { get; set; }
        public string FromIp { get; set; }
        public int ChannelType { get; set; }
        public string ChannelCode { get; set; }
        public decimal Amount { get; set; }
    }
}
