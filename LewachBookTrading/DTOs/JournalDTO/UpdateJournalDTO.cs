namespace LewachBookTrading.DTOs.JournalDTO
{
    public class UpdateJournalDTO
    {
        public int JournalID { get; set; }
        public string JournalName { get; set; }
        public string JournalContent { get; set; }

        public int UsertId { get; set; }

        public int JournalTypeId { get; set; }

        public List<UpdateJournalPhotoDTO>? JournalPhotos { get; set; } = new List<UpdateJournalPhotoDTO>();

    }
    public class UpdateJournalPhotoDTO
    {
        public string PhotoUrl { get; set; }
    }
}
