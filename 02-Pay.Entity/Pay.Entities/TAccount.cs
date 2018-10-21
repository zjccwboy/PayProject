
namespace Pay.Entities
{
    public partial class TAccount: BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Emai { get; set; }
        public int Type { get; set; }
        public int SecretProblem { get; set; }
        public int SecretAnswer { get; set; }
    }
}
