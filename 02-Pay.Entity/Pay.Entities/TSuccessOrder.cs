using System;

namespace Pay.Entities
{
    public partial class TSuccessOrder : BaseEntity
    {
        [Key]
        public long OderNum { get; set; }
        public string Mnum { get; set; }
        public int Mid { get; set; }
        public bool State { get; set; }
        public string FromIp { get; set; }
        public int ChannelType { get; set; }
        public string ChannelCode { get; set; }
        public decimal Amount { get; set; }
        public bool NotifyState { get; set; }
        public string NotifyUrl { get; set; }
        public string AlipayId { get; set; }
        public decimal Percentage { get; set; }
        public DateTime? FrozenTime { get; set; }
        public int FrozenState { get; set; }
        public int RefundState { get; set; }
        public DateTime? RefundTime { get; set; }
    }
}
