using LewachBookTrading.Model;

namespace LewachBookTrading.DTOs.JournalDTO
{
    public class DisplayJournalDTO
    {
        public string JournalName { get; set; }
        public string JournalContent { get; set; }

        public DateTime JournalEntryDate { get; set; } 

        public DateTime JournalUpdateDate { get; set; }

        public ICollection<JournalPhoto>? JournalPhotos { get; set; }

        public int JournalTagID { get; set; }

        public JournalTags? Tag { get; set; }

    }
}
