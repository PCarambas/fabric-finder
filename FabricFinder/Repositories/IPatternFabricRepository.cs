using FabricFinder.Models;
using System.Collections.Generic;

namespace FabricFinder.Repositories
{
    public interface IPatternFabricRepository
    {
        List<PatternFabric> GetByUserId(int UserId); 
        void AddPatternFabric(PatternFabric patternFabric);
        void Delete(int patternFabricId, int UserId);
    }
}
