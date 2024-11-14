using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LewachBookTrading.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Genre { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public User? Owner { get; set; }
        public int OwnerId { get; set; }

        public List<Experience>? Experiences { get; set; }

        public List<Trade>? Trades { get; set; }

        //[NotMapped]
        //public IFormFile? CoverPage { get; set; }

        //public string? CoverPagePath { get; set; }
    }
}
