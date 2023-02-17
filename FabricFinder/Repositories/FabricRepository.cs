using FabricFinder.Models;
using FabricFinder.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace FabricFinder.Repositories
{
    public class FabricRepository : BaseRepository, IFabricRepository
    {
        public FabricRepository(IConfiguration configuration) : base(configuration) { }

        public void AddPatternFabric(PatternFabric patternFabric)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO PatternFabric (
                        UserId,
                        FabricId,
                        PatternId
                        )
                        
                        
                       
	                    
                        VALUES (
                        @UserId,
                        @FabricId,
                        @PatternId)
                        ";



                    DbUtils.AddParameter(cmd, "@UserId", patternFabric.UserId);
                    DbUtils.AddParameter(cmd, "@FabricId", patternFabric.FabricId);
                    DbUtils.AddParameter(cmd, "@PatternId", patternFabric.PatternId);

                    cmd.ExecuteNonQuery();
                    
                }
            }
        }

        public int Add(Fabric fabric)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Fabric (
                        Name,
                        Color,
                        Yardage,
                        ImageUrl,
                        FabricTypeId,
                        UserId
                        )
                        
                        OUTPUT INSERTED.ID
	                    
                        VALUES (
                        @Name,
                        @Color,
                        @Yardage,
                        @ImageUrl,
                        @FabricTypeId,
                        @UserId)
                        ";

                    DbUtils.AddParameter(cmd, "@Name", fabric.Name);
                    DbUtils.AddParameter(cmd, "@Color", fabric.Color);
                    DbUtils.AddParameter(cmd, "@Yardage", fabric.Yardage);
                    DbUtils.AddParameter(cmd, "@ImageUrl", fabric.ImageUrl);
                    DbUtils.AddParameter(cmd, "@FabricTypeId", fabric.FabricTypeId);
                    DbUtils.AddParameter(cmd, "@UserId", fabric.UserId);

                    fabric.Id = (int)cmd.ExecuteScalar();
                    return fabric.Id;
                }
            }
        }



        public List<Fabric> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT f.Id, f.Name, f.Color, f.Yardage, f.ImageUrl, f.UserId, 
                         ft.Type, ft.id AS fabricTypeId,
		                p.Id AS patternId, p.Name AS patternName, p.ImageUrl AS patternImageUrl
                        
                        

		                FROM Fabric f
                           LEFT JOIN PatternFabric pf ON f.Id = pf.fabricId
                            LEFT JOIN Pattern p ON p.Id = pf.patternId
                        JOIN FabricType ft ON f.FabricTypeId = ft.id
                        ";



                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        var fabrics = new List<Fabric>();
                        Fabric existingFabric = null;
                        while (reader.Read())
                        {
                            var fabricId = DbUtils.GetInt(reader, "Id");
                            existingFabric = fabrics.FirstOrDefault(f => f.Id == fabricId);
                            if (existingFabric == null)
                            {
                                existingFabric = new Fabric()
                                {
                                    Id = fabricId,
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Color = DbUtils.GetString(reader, "Color"),
                                    Yardage = DbUtils.GetDouble(reader, "Yardage"),
                                    ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                    UserId = DbUtils.GetInt(reader, "UserId"),
                                    FabricTypeId = DbUtils.GetInt(reader, "FabricTypeId"),
                                    FabricType = new FabricType()
                                    {
                                        Id = DbUtils.GetInt(reader, "FabricTypeId"),
                                        Type = DbUtils.GetString(reader, "Type"),
                                    },
                                    Patterns = new List<Pattern>()
                                };
                                fabrics.Add(existingFabric);
                            }

                            if (DbUtils.IsNotDbNull(reader, "PatternId"))
                            {
                                existingFabric.Patterns.Add(new Pattern()
                                {
                                    Id = DbUtils.GetInt(reader, "patternId"),
                                    Name = DbUtils.GetString(reader, "patternName"),
                                    ImageUrl = DbUtils.GetString(reader, "patternImageUrl")
                                });
                            }
                        }
                        reader.Close();

                        return fabrics;
                    }
                }
            }
        }

        public Fabric GetFabricById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT f.Id, f.Name, f.Color, f.Yardage, f.ImageUrl, f.UserId, 
                        ft.Type, ft.id AS fabricTypeId,
		                up.FirebaseUserId, up.Email

		                FROM Fabric f

		                JOIN UserProfile up ON f.UserId = up.Id
                        JOIN FabricType ft ON f.FabricTypeId = ft.id

                        WHERE f.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Fabric fabric = null;
                        if (reader.Read())
                        {
                            fabric = new Fabric()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                Name = DbUtils.GetString(reader, "Name"),
                                Color = DbUtils.GetString(reader, "Color"),
                                Yardage = DbUtils.GetDouble(reader, "Yardage"),
                                ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                UserId = DbUtils.GetInt(reader, "UserId"),
                                FabricTypeId = DbUtils.GetInt(reader, "FabricTypeId"),
                                FabricType = new FabricType()
                                {
                                    Id = DbUtils.GetInt(reader, "FabricTypeId"),
                                    Type = DbUtils.GetString(reader, "Type"),
                                },
                                UserProfile = new UserProfile()
                                {
                                    Id = DbUtils.GetInt(reader, "UserId"),
                                    FirebaseUserId = DbUtils.GetString(reader, "FireBaseUserId"),
                                    Email = DbUtils.GetString(reader, "Email"),
                                }

                            };
                        }
                        return fabric;
                    }
                }
            }
        }




        public List<Fabric> GetByUserId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT f.Id, f.Name, f.Color, f.Yardage, f.ImageUrl, f.UserId, 
                         ft.Type, ft.id AS fabricTypeId,
		                p.Id AS patternId, p.Name AS patternName, p.ImageUrl AS patternImageUrl
                        
                        

		                FROM Fabric f
                           LEFT JOIN PatternFabric pf ON f.Id = pf.fabricId
                            LEFT JOIN Pattern p ON p.Id = pf.patternId
                        JOIN FabricType ft ON f.FabricTypeId = ft.id
            
                        WHERE f.UserId = @UserId
                        ";
                    cmd.Parameters.AddWithValue("@UserId", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        var fabrics = new List<Fabric>();
                        Fabric existingFabric = null;
                        while (reader.Read())
                        {
                            var fabricId = DbUtils.GetInt(reader, "Id");
                            existingFabric = fabrics.FirstOrDefault(f => f.Id == fabricId);
                            if (existingFabric == null)
                            {
                                existingFabric = new Fabric()
                                {
                                    Id = fabricId,
                                    Name = DbUtils.GetString(reader, "Name"),
                                    Color = DbUtils.GetString(reader, "Color"),
                                    Yardage = DbUtils.GetDouble(reader, "Yardage"),
                                    ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                                    UserId = DbUtils.GetInt(reader, "UserId"),
                                    FabricTypeId = DbUtils.GetInt(reader, "FabricTypeId"),
                                    FabricType = new FabricType()
                                    {
                                        Id = DbUtils.GetInt(reader, "FabricTypeId"),
                                        Type = DbUtils.GetString(reader, "Type"),
                                    },
                                    Patterns = new List<Pattern>()
                                };
                                fabrics.Add(existingFabric);
                            }

                            if (DbUtils.IsNotDbNull(reader, "PatternId"))
                            {
                                existingFabric.Patterns.Add(new Pattern()
                                {
                                    Id = DbUtils.GetInt(reader, "patternId"),
                                    Name = DbUtils.GetString(reader, "patternName"),
                                    ImageUrl = DbUtils.GetString(reader, "patternImageUrl")
                                });
                            }
                        }
                        reader.Close();

                        return fabrics;
                    }

                }
            }
        }

        public void Update(Fabric fabric)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Fabric
                        SET 
                        [Name] = @Name,
                        [Color] = @Color,
                        [Yardage] = @Yardage,
                        [ImageUrl] = @ImageUrl,
                        [FabricTypeId] = FabricTypeId

                        WHERE Id = @Id
                        ";

                    DbUtils.AddParameter(cmd, "@Id", fabric.Id);
                    DbUtils.AddParameter(cmd, "@Name", fabric.Name);
                    DbUtils.AddParameter(cmd, "@Color", fabric.Color);
                    DbUtils.AddParameter(cmd, "@Yardage", fabric.Yardage);
                    DbUtils.AddParameter(cmd, "@ImageUrl", fabric.ImageUrl);
                    DbUtils.AddParameter(cmd, "@FabricTypeId", fabric.FabricTypeId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    DELETE FROM Fabric
                    WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }

            }

        }
    }
}












