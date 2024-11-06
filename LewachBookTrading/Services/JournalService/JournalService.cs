using DentalClinic.Services.Tools;
using LewachBookTrading.Context;
using LewachBookTrading.DTOs.JournalDTO;
using LewachBookTrading.DTOs.JournalTypesDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
                // Handle the case where the role is not found
                throw new Exception("Role not found.");
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
                if (user == null)
                {
                    // Handle the case where the role is not found
                    throw new Exception("Role not found.");
                }
            }

            if (DTO.JournalPhotos != null && DTO.JournalPhotos.Any())
            {
                journal.JournalPhotos = DTO.JournalPhotos.Select(photoDto => new JournalPhoto
                {
                    PhotoUrl = photoDto.PhotoUrl,
                    Journal = journal
                }).ToList();
            }

            await _context.Journals.AddAsync(journal);
            await _context.SaveChangesAsync();
            return journal;
        }

        public async Task<Journal> UpdateJournal(UpdateJournalDTO DTO)
        {
            var journal = await _context.Journals.
                            Include(j => j.JournalPhotos) // Include JournalPhotos to load existing photos
                            .FirstOrDefaultAsync(j => j.Id == DTO.JournalID);

            var journalType = await _context.JournalTags.FirstOrDefaultAsync(j => j.Id == DTO.JournalTypeId);

            if (journalType == null)
            {
                // Handle the case where the role is not found
                throw new Exception("Role not found.");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == DTO.UsertId);
            if (user != null)
            {
                //journal.UsertId = user.Id;
                //journal.User = user;
                //journal.JournalTagID = DTO.JournalTypeId;
            }
            else
            {
                if (user == null)
                {
                    // Handle the case where the role is not found
                    throw new Exception("Role not found.");
                }
            }

            journal.JournalUpdateDate = DateTime.Now;
            journal.JournalName = DTO.JournalName;
            journal.JournalContent = DTO.JournalContent;
            journal.JournalTagID = DTO.JournalTypeId;


            if (DTO.JournalPhotos != null && DTO.JournalPhotos.Any())
            {
                var newPhotos = DTO.JournalPhotos.Select(photoDto => new JournalPhoto
                {
                    PhotoUrl = photoDto.PhotoUrl,
                    Journal = journal
                }).ToList();

                // Add new photos to the existing collection
                var photosList = journal.JournalPhotos.ToList();
                photosList.AddRange(newPhotos);
                journal.JournalPhotos = photosList;
            }

             _context.Journals.Update(journal);
            //journal.
            await _context.SaveChangesAsync();

            return journal;

        }

        public async Task<List<DisplayJournalDTO>> GetJournalsByUser(int userId)
        {
            // Fetch journals for the specified user
            var journals = await _context.Journals
                .Include(j => j.JournalPhotos)
                .Where(j => j.UsertId == userId)
                .Select(j => new DisplayJournalDTO
                {
                    JournalId = j.Id,
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

        public async Task<JournalPhoto> RemoveJournalPhoto(int JournalPhoto)
        {
            var journalPhoto = await _context.JournalPhotos.FirstOrDefaultAsync(jt => jt.Id == JournalPhoto);

            if (journalPhoto == null)
            {
                // Handle the case where the role is not found
                throw new Exception("Role not found.");
            }

            _context.JournalPhotos.Remove(journalPhoto);
            await _context.SaveChangesAsync();

            return journalPhoto;
        }

        public async Task<Journal> DeleteJournal(int JournalId)
        {
            var journal = await _context.Journals.FirstOrDefaultAsync(j => j.Id == JournalId);
            if (journal == null)
            {
                // Handle the case where the role is not found
                throw new Exception("Role not found.");
            }
            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();
            return journal;
        }


        public async Task<JournalPhoto> GetJournalPhoto(int PhotoId)
        {
            var journalPhoto = await _context.JournalPhotos
                                            .FirstOrDefaultAsync(jt => jt.Id == PhotoId);
            if (journalPhoto == null)
            {
                // Handle the case where the role is not found
                throw new Exception("Role not found.");
            }
            return journalPhoto;
        }


        public async Task<DisplayJournalDTO> GetSpecificJournal(int id)
        {
            var journal = await _context.Journals
                                        .Where(j => j.Id == id)
                                        .Include(j => j.JournalPhotos)
                                        .FirstOrDefaultAsync();

            var tags = await _context.JournalTags.Where(j => j.Id == journal.JournalTagID).FirstOrDefaultAsync();

            if (journal == null)
            {
                // Handle the case where the role is not found
                throw new Exception("Role not found.");
            }
            DisplayJournalDTO res = new DisplayJournalDTO();

            res.JournalId = journal.Id;
            res.JournalPhotos = journal.JournalPhotos;
            res.JournalName = journal.JournalName;
            res.JournalContent = journal.JournalContent;
            res.JournalUpdateDate = journal.JournalUpdateDate;
            res.JournalEntryDate = journal.JournalEntryDate;
            res.JournalTagID = journal.JournalTagID;
            res.JournalPhotos = journal.JournalPhotos;
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
