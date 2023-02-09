using Azure;
using FabricFinder.Models;
using System.Collections.Generic;

namespace FabricFinder.Repositories
{
    public interface IFabricRepository
    {
        List<Fabric> GetAll();
        void Add(Fabric fabric);
        void Update(Fabric fabric);
        void Delete(int id);
        object GetById(int id);
    }
}