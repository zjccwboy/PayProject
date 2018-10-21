
namespace Pay.Entities
{
    public partial class TPercentage : BaseEntity
    {
        [Key]
        public long AccountId { get; set; }
        public decimal Percentage { get; set; }
        public int ChannelType { get; set; }
    }
}
