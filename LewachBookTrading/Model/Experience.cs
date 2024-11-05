using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public User? FromUser { get; set; }

        public int FromUserId { get; set; }
        public string? Content { get; set; }
        public Book? ToBook { get; set; }

        public int ToBookId { get; set; }

    }
}
