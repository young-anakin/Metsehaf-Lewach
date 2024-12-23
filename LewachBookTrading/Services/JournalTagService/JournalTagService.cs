﻿using DentalClinic.Services.Tools;
using LewachBookTrading.Context;
using LewachBookTrading.DTOs.JournalTypesDTO;
using LewachBookTrading.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LewachBookTrading.Services.JournalTypeService
{
    public class JournalTagService : IJournalTagService
    {
        private readonly DataContext _context;
        private readonly IToolsService _toolsService;

        public JournalTagService(DataContext context, IToolsService toolsService)
        {
            _context = context;
            _toolsService = toolsService;

        }

        public async Task<JournalTags> AddJournalTag(AddJournalTypeDTO DTO)
        {
            JournalTags jt = new JournalTags();
            jt.JorunalTag = DTO.JournalTag;

            var user = await _context.Users.Where(u => u.Id == DTO.UserId).FirstOrDefaultAsync();

            if (user == null)
            {
                // Handle the case where the role is not found
                throw new Exception("User not found.");
            }

            jt.UserId = DTO.UserId;
            jt.User = user;

            await _context.JournalTags.AddAsync(jt);
            await _context.SaveChangesAsync();
            return jt;
        }

        public async Task<List<JournalTags>> GetJournalTagsByUser(int Userid)
        {
            var jt = await _context.JournalTags.Where(jt => jt.User.Id == Userid).ToListAsync();
            return jt;
        }

        public async Task<JournalTags> UpdateJournalTag(UpdateJournalTypeDTO DTO)
        {
            var jt = await _context.JournalTags.Where(jt => jt.Id == DTO.JournalId).FirstOrDefaultAsync();
            jt.JorunalTag = DTO.JournalTag;

            _context.JournalTags.Update(jt);
            await _context.SaveChangesAsync();
            return jt;
        }

        public async Task<JournalTags> DeleteJournalTag(int id)
        {
            var tag = await _context.JournalTags.FirstOrDefaultAsync(jt => jt.Id == id);

            _context.JournalTags.Remove(tag);   
            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
