using FabricFinder.Models;
using System.Collections.Generic;

namespace FabricFinder.Repositories
{
    public interface IPatternRepository
    {
        List<Pattern> GetAll();
        Pattern GetPatternById(int id);
        void Add(Pattern pattern);
        void Update(Pattern pattern);
        void Delete(int id);
        List<Pattern> GetByUserId(int firebaseId);
        
    }
}