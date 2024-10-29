using LewachBookTrading.DTOs.JournalTypesDTO;
using LewachBookTrading.Model;

namespace LewachBookTrading.Services.JournalTypeService
{
    public interface IJournalTagService
    {
        Task<JournalTags> AddJournalTag(AddJournalTypeDTO DTO);
        Task<List<JournalTags>> GetJournalTagsByUser(int Userid);
        Task<JournalTags> UpdateJournalTag(UpdateJournalTypeDTO DTO);
    }
}