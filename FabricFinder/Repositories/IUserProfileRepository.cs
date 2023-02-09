using FabricFinder.Models;
using System.Collections.Generic;

namespace FabricFinder.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        List<UserProfile> GetAll();
        
    }
}