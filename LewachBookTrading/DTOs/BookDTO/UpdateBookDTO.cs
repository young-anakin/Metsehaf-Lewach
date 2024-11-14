namespace LewachBookTrading.DTOs.BookDTO
{
    public class UpdateBookDTO
    {
        public int Id { get; set; }
        public string? Genre { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        //public User? Owner { get; set; }
        public int OwnerId { get; set; }

        //public List<Experience>? Experiences { get; set; }

        //public List<Trade>? Trades { get; set; }
    }
}
