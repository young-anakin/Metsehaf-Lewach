using LewachBookTrading.DTOs.JournalDTO;
using LewachBookTrading.Model;

namespace LewachBookTrading.Services.JournalService
{
    public interface IJournalService
    {
        Task<Journal> AddJournal(AddJournalDTO DTO);
        Task<List<DisplayJournalDTO>> GetJournalsByUser(int id);
        Task<DisplayJournalDTO> GetSpecificJournal(int id);
    }
}