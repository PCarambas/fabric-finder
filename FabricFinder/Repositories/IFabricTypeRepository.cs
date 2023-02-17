using FabricFinder.Models;
using System.Collections.Generic;

namespace FabricFinder.Repositories
{
    public interface IFabricTypeRepository
    {
        List<FabricType> GetAll();
    }
}