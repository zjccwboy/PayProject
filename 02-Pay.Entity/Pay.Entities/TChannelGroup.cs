
namespace Pay.Entities
{
    public partial class TChannelGroup : BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string GroupName { get; set; }
        public long GroupType { get; set; }
        public string Channels { get; set; }
    }
}
