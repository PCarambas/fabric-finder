using Azure;
using FabricFinder.Models;
using FabricFinder.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;



namespace FabricFinder.Repositories
{
    public class PatternRepository : BaseRepository, IPatternRepository
    {
        public PatternRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Pattern pattern)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Pattern (
                        Name,
                        ImageUrl,
                        UserId
                        )
                        
                        
                        OUTPUT INSERTED.ID
	                    
                        VALUES (
                        @Name,
                        @ImageUrl,
                        @UserId)
                        ";

                    DbUtils.AddParameter(cmd, "@Name", pattern.Name);
                    DbUtils.AddParameter(cmd, "@ImageUrl", pattern.ImageUrl);
                    DbUtils.AddParameter(cmd, "@UserId", pattern.UserId);
                    pattern.Id = (int)cmd.ExecuteScalar();

                }
            }
        }
        public List<Pattern> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT p.Id, p.Name, p.ImageUrl,
                         up.FirebaseUserId, up.Email
                        
                        FROM Pattern p
                        JOIN UserProfile up ON p.UserId = up.Id
                        ";


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        var patterns = new List<Pattern>();
                        while (reader.Read())
                        {
                            patterns.Add(new Pattern()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),

                            });
                        }
                        return patterns;
                    }
                }
            }
        }

                        

        public List<Pattern> GetByUserId(int firebaseId)
        {
            throw new System.NotImplementedException();
        }

        public Pattern GetPatternById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT p.Id, p.Name, p.ImageUrl, p.UserId, 
		                up.FirebaseUserId, up.Email

		                FROM Pattern p

		                JOIN UserProfile up ON p.UserId = up.Id
                        

                        WHERE p.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Pattern pattern = null;
                        if (reader.Read())
                        {
                            pattern = new Pattern()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                               
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                UserId = DbUtils.GetInt(reader, "UserId"),
                                
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FireBaseUserId"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                }

                            };
                        }
                        return pattern;
                    }
                }
            }
        }

        public void Update(Pattern pattern)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}



    
                        


                        
                        


