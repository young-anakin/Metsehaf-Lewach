using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class JournalTags
    {
        [Key]
        public int Id { get; set; }
        
        public string JorunalTag { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]

        public int UserId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public User User { get; set; }

        public List<Journal> Journals { get; set; }
    }
}
