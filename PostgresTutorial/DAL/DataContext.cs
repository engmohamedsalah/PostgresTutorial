using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PostgresTutorial.Model;

namespace PostgresTutorial.DAL
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public IEnumerable<string> GetAllSchemas()
        {
            var schemas = new List<string>();

            using (var connection = Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT Distinct schema_name FROM information_schema.schemata ";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                schemas.Add(reader.GetString(0));
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return schemas;
        }

        public IEnumerable<string> GetAllTables(string schemaName = "public")
        {
            var tableNames = new List<string>();

            using (var connection = Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT Distinct TABLE_NAME FROM information_schema.TABLES where table_schema ='{schemaName}'";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                tableNames.Add(reader.GetString(0));
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return tableNames;
        }

        public DBTable GetAllColumns(string tableName)
        {
            var result = new DBTable(tableName);

            using (var connection = Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME ='{tableName}'";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result.Fields.Add(reader["column_name"].ToString(), reader["data_type"].ToString());
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return result;
        }

        //public List<string> GETALL()
        //{
        //    List<string> results = db.Database.SqlQuery<string>("SELECT name FROM sys.tables ORDER BY name").ToList();
        //    return results;
        //}
    }
}