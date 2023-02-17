using FabricFinder.Models;
using FabricFinder.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FabricFinder.Repositories
{
    public class PatternFabricRepository : BaseRepository, IPatternFabricRepository
    {
        public PatternFabricRepository(IConfiguration configuration) : base(configuration) { }

        public void AddPatternFabric(PatternFabric patternFabric)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int patternFabricId, int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    DELETE FROM PatternFabric
                    WHERE PatternFabricId = @patternFabricId";
                    

                    cmd.Parameters.AddWithValue("@patternFabricId", patternFabricId);
                    
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public List<PatternFabric> GetByUserId(int UserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT * 
                        FROM PatternFabric
                        WHERE UserId = @userId
                        ";
                    cmd.Parameters.AddWithValue("@userId", UserId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var patternfabrics = new List<PatternFabric>();
                        while (reader.Read())
                        {
                            var patternFabric = new PatternFabric
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                UserId = DbUtils.GetInt(reader, "UserId"),
                                FabricId = DbUtils.GetInt(reader, "FabricId"),
                                PatternId = DbUtils.GetInt(reader, "PatternId"),
                            };
                          patternfabrics.Add(patternFabric);
                        }
                        reader.Close();

                        return patternfabrics;
                    }
                }
            }
        }
    }
}
