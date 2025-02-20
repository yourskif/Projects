using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UnivercityDepartment.Models;

namespace UnivercityDepartment.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly UnivercityContext _context;

        public FacultyService(UnivercityContext context)
        {
            _context = context;
        }

        public async Task<List<Faculty>> GetAllFacultiesAsync()
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task ImportFacultiesFromJsonAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            var json = await File.ReadAllTextAsync(filePath);
            var faculties = JsonSerializer.Deserialize<List<Faculty>>(json);

            if (faculties != null)
            {
                _context.Faculties.AddRange(faculties);
                await _context.SaveChangesAsync();
            }
        }
    }
}
