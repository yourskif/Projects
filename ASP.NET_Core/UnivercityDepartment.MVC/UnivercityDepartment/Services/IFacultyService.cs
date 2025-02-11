using System.Collections.Generic;
using System.Threading.Tasks;
using UnivercityDepartment.Models;

namespace UnivercityDepartment.Services
{
    public interface IFacultyService
    {
        Task<List<Faculty>> GetAllFacultiesAsync();
        Task ImportFacultiesFromJsonAsync(string filePath);
    }
}
