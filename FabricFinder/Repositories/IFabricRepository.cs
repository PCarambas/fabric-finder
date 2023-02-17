using Azure;
using FabricFinder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FabricFinder.Repositories
{
    public interface IFabricRepository
    {
        List<Fabric> GetAll();
        Fabric GetFabricById(int id);
        int Add(Fabric fabric);
        void Update(Fabric fabric);
        void Delete(int id);
        List<Fabric> GetByUserId(int firebaseId);
        void AddPatternFabric(PatternFabric patternFabric);
    }
}