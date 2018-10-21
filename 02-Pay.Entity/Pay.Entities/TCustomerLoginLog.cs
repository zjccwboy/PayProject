
namespace Pay.Entities
{
    public partial class TCustomerLoginLog : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public long? AccountId { get; set; }
        public string LoginIp { get; set; }
    }
}
