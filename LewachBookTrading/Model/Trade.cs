using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Trade
    {
        [Key]
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public User? FromUser { get; set; }
        public User? ToUser { get; set; }
        public DateTime CreatedAt{ get; set; }
    }
}
