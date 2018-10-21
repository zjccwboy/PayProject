
namespace Pay.Entities
{
    public partial class TAdminLoginLog: BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string LoginIp { get; set; }
    }
}
