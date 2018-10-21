
namespace Pay.Entities
{
    public partial class TMerchant : BaseEntity
    {
        [Key]
        public long AccountId { get; set; }
        public int Mid { get; set; }
        public string PayeeName { get; set; }
        public string BankName { get; set; }
        public string BankCard { get; set; }
        public string BankAddress { get; set; }
        public decimal AmountTotal { get; set; }
        public int? State { get; set; }
        public string WithdrawPwd { get; set; }
        public string Rsa2key { get; set; }
        public string RecvNotifyUrl { get; set; }
        public bool SyncJumpUrl { get; set; }
        public int DfuserGroup { get; set; }
    }
}
