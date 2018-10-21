
namespace Pay.Entities
{
    public partial class TAdminOperationLog: BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public long? AccountId { get; set; }
        public int LogType { get; set; }
        public string LogContent { get; set; }
    }
}
