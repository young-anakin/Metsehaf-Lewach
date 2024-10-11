using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class JournalPhoto
    {
        [Key]
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public int JournalId { get; set; }
        public Journal Journal { get; set; }
    }
}
