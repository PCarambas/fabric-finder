using FabricFinder.Models;
using FabricFinder.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;



namespace FabricFinder.Repositories
{
    public class FabricRepository : BaseRepository, IFabricRepository
    {
        public FabricRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Fabric fabric)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Fabric> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT f.Id, f.Name, f.Color, f.Yardage, f.ImageUrl, f.UserId, f.FabricTypeId,
		                up.FirebaseUserId, up.Email

		                FROM Fabric f

		                JOIN UserProfile up ON f.UserId = up.Id
                        ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        var fabrics = new List<Fabric>();
                        while (reader.Read())
                        {
                            fabrics.Add(new Fabric()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Color = DbUtils.GetString(reader, "Color"),
                                Yardage = DbUtils.GetDouble(reader, "Yardage"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                UserId = DbUtils.GetInt(reader, "UserId"),
                                FabricTypeId = DbUtils.GetInt(reader, "FabricTypeId"),
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FireBaseUserId"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                },
                            });
                        }

                        return fabrics;
                    }
                }
            }
        }

        public object GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Fabric fabric)
        {
            throw new System.NotImplementedException();
        }
    }
}
                                
                                    
                                    
    
