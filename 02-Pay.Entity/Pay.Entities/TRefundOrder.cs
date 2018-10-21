
namespace Pay.Entities
{
    public partial class TRefundOrder : BaseEntity
    {
        [Key]
        public long OderNum { get; set; }
        public string Mnum { get; set; }
        public int Mid { get; set; }
        public decimal Amount { get; set; }
        public int RefundType { get; set; }
        public decimal RefundCharge { get; set; }
        public decimal RefundAmount { get; set; }
    }
}
