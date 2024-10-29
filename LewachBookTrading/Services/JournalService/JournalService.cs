using DentalClinic.Services.Tools;
using LewachBookTrading.Context;
using LewachBookTrading.DTOs.JournalDTO;
using LewachBookTrading.DTOs.JournalTypesDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;

namespace LewachBookTrading.Services.JournalService
{
    public class JournalService : IJournalService
    {
        private readonly DataContext _context;
        private readonly IToolsService _toolsService;

        public JournalService(DataContext context, IToolsService toolsService)
        {
            _context = context;
            _toolsService = toolsService;

        }

        public async Task<Journal> AddJournal(AddJournalDTO DTO)
        {
            Journal journal = new Journal();
            journal.JournalName = DTO.JournalName;
            journal.JournalContent = DTO.JournalContent;

            var journalType = await _context.JournalTags.FirstOrDefaultAsync(j => j.Id == DTO.JournalTypeId);

            if (journalType == null)
            {
                string s = "not found";
                return null;
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == DTO.UsertId);
            if (user != null)
            {
                journal.UsertId = user.Id;
                journal.User = user;
                journal.JournalTagID = DTO.JournalTypeId;
            }
            else
            {
                return null;
            }

            await _context.Journals.AddAsync(journal);
            await _context.SaveChangesAsync();
            return journal;
        }

        public async Task<List<DisplayJournalDTO>> GetJournalsByUser(int userId)
        {
            // Fetch journals for the specified user
            var journals = await _context.Journals
                .Where(j => j.UsertId == userId)
                .Select(j => new DisplayJournalDTO
                {
                    JournalName = j.JournalName,
                    JournalContent = j.JournalContent,
                    JournalEntryDate = j.JournalEntryDate,
                    JournalUpdateDate = j.JournalUpdateDate,
                    JournalPhotos = j.JournalPhotos,
                    JournalTagID = j.JournalTagID,
                    Tag =  _context.JournalTags.FirstOrDefault(t => t.Id == j.JournalTagID)  // Fetch the associated tag
                })
                .ToListAsync();

            return journals;
        }


        public async Task<DisplayJournalDTO> GetSpecificJournal(int id)
        {
            var journal = await _context.Journals
                                        .Where(j => j.Id == id)
                                        .FirstOrDefaultAsync();

            var tags = await _context.JournalTags.Where(j => j.Id == journal.JournalTagID).FirstOrDefaultAsync();

            if (journal == null)
            {

            return null;
            }
            DisplayJournalDTO res = new DisplayJournalDTO();

            res.JournalPhotos = journal.JournalPhotos;
            res.JournalName = journal.JournalName;
            res.JournalContent = journal.JournalContent;
            res.JournalUpdateDate = journal.JournalUpdateDate;
            res.JournalEntryDate = journal.JournalEntryDate;
            res.JournalTagID = journal.JournalTagID;
            if (tags == null)
            {
                res.Tag = null;
            }
            else
            {
                res.Tag = tags;
            }




            return res;
        }
    }
}
