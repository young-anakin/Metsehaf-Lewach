using LewachBookTrading.Model;

namespace LewachBookTrading.DTOs.BookDTO
{
    public class AddBookDTO
    {
        public string? Genre { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        //public User? Owner { get; set; }
        public int OwnerId { get; set; }

        //public List<Experience>? Experiences { get; set; }

        //public List<Trade>? Trades { get; set; }

        //public IFormFile? CoverPage { get; set; }
        //public string? CoverPagePath { get; set; }
    }
}
