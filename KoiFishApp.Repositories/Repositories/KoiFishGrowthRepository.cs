﻿using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Repositories
{
    public class KoiFishGrowthRepository : IKoiFishGrowthRepository
    {
        private readonly QlcktnContext _context;

        public KoiFishGrowthRepository(QlcktnContext context)
        {
            _context = context;
        }
        public async Task AddGrowthRecordAsync(KoiGrowth record)
        {
            _context.KoiGrowths.Add(record); // Thêm bản ghi phát triển mới vào DbSet
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        public async Task<List<KoiGrowth>> GetGrowthRecordsByKoiFishIdAsync(int koiId)
        {
            return await _context.KoiGrowths.Where(g => g.KoiId == koiId).OrderBy(g => g.Date).ToListAsync(); // Trả về danh sách các bản ghi phát triển
        }
        public async Task<KoiGrowth> GetGrowthRecordByIdAsync(int koiGrowthId)
        {
            return await _context.KoiGrowths
                .FirstOrDefaultAsync(g => g.KoiGrowthId == koiGrowthId);
        }

        public async Task UpdateGrowthRecordAsync(KoiGrowth koiGrowth)
        {
            // Cập nhật bản ghi trong cơ sở dữ liệu
            _context.KoiGrowths.Update(koiGrowth);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteGrowthRecordAsync(int koiGrowthId)
        {
            var record = await _context.KoiGrowths.FindAsync(koiGrowthId);
            if (record != null)
            {
                _context.KoiGrowths.Remove(record);
                await _context.SaveChangesAsync();
            }
        }

    }
}
