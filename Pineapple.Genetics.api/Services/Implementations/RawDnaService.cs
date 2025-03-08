using Microsoft.EntityFrameworkCore;
using Pineapple.Genetics.api.Data;
using Pineapple.Genetics.api.Data.Entities;
using Pineapple.Genetics.api.Services.Abstractions;

namespace Pineapple.Genetics.api.Services.Implementations
{
    public class RawDnaService(ApplicationDbContext dbContext) : IRawDnaService
    {
        public async Task AddAsync(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileBytes = memoryStream.ToArray();

            // Create the entity
            var csvRecord = new RawDna
            {
                FileName = file.FileName,
                GeneticFile = fileBytes
            };

            // Save to the database
            try
            {
                _context.CsvFileRecords.Add(csvRecord);
                await _context.SaveChangesAsync();
                return Ok(new { Id = csvRecord.Id, Message = "File uploaded successfully." });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Failed to save file: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }
}
