using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Journal
    {
        [Key]
        public int Id { get; set; }

        public string JournalName { get; set; }
        public string JournalContent { get; set; }

        public DateTime JournalEntryDate { get; set; } = DateTime.Now;

        public DateTime JournalUpdateDate { get; set; }

        public ICollection<JournalPhoto> JournalPhotos { get; set; }

        public JournalTags Tag {  get; set; }


        public int UsertId { get; set; }

        public User User { get; set; }


    }
}
