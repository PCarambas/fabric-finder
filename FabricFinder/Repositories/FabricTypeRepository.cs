using FabricFinder.Models;
using FabricFinder.Utils;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;



namespace FabricFinder.Repositories
{
    public class FabricTypeRepository : BaseRepository, IFabricTypeRepository
    {
        public FabricTypeRepository(IConfiguration configuration) : base(configuration) { }

        public List<FabricType> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Type
		                FROM FabricType 
                        ";
                        


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        var fabricTypes = new List<FabricType>();
                        while (reader.Read())
                        {
                            fabricTypes.Add(new FabricType()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Type = DbUtils.GetString(reader, "Type"),

                            });
                        }
                        reader.Close();

                        return fabricTypes;
                    }
                }
            }
        }
    }
}

