using LewachBookTrading.Model;

namespace LewachBookTrading.DTOs.JournalDTO
{
    public class AddJournalDTO
    {

        public string JournalName { get; set; }
        public string JournalContent { get; set; }


        //public JournalTags Tag {  get; set; }


        public int UsertId { get; set; }

        public int JournalTypeId { get; set; }

    }

}
