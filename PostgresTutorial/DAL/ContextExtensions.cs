//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Core.Objects;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using PostgresTutorial.Model;

//namespace PostgresTutorial.DAL
//{
//    public static class ContextExtensions
//    {
//        public static IEnumerable<string> GetAllSchemas(this DbContext @this)
//        {
//            var schemas = new List<string>();

//            using (var connection = @this.Database.GetDbConnection())
//            {
//                connection.Open();
//                using (var command = connection.CreateCommand())
//                {
//                    command.CommandText = $"SELECT Distinct schema_name FROM information_schema.schemata ";
//                    using (var reader = command.ExecuteReader())
//                    {
//                        if (reader.HasRows)
//                        {
//                            while (reader.Read())
//                            {
//                                schemas.Add(reader.GetString(0));
//                            }
//                        }
//                        reader.Close();
//                    }
//                }
//                connection.Close();
//            }
//            return schemas;
//        }

//        public static IEnumerable<string> GetTableNames(this DbContext @this, string schemaName = "public")
//        {
//            var tableNames = new List<string>();

//            using (var connection = @this.Database.GetDbConnection())
//            {
//                connection.Open();
//                using (var command = connection.CreateCommand())
//                {
//                    command.CommandText = $"SELECT Distinct TABLE_NAME FROM information_schema.TABLES where table_schema ='{schemaName}'";
//                    using (var reader = command.ExecuteReader())
//                    {
//                        if (reader.HasRows)
//                        {
//                            while (reader.Read())
//                            {
//                                tableNames.Add(reader.GetString(0));
//                            }
//                        }
//                        reader.Close();
//                    }
//                }
//                connection.Close();
//            }
//            return tableNames;
//        }

//        public static DBTable GetAllColumns(this DbContext @this, string tableName)
//        {
//            var result = new DBTable(tableName);

//            using (var connection = @this.Database.GetDbConnection())
//            {
//                connection.Open();
//                using (var command = connection.CreateCommand())
//                {
//                    command.CommandText = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME ='{tableName}'";
//                    using (var reader = command.ExecuteReader())
//                    {
//                        if (reader.HasRows)
//                        {
//                            while (reader.Read())
//                            {
//                                result.Fields.Add(reader["column_name"].ToString(), reader["data_type"].ToString());
//                            }
//                        }
//                        reader.Close();
//                    }
//                }
//                connection.Close();
//            }
//            return result;
//        }

//        public static string GetTableName<T>(this DbContext context) where T : class
//        {
//            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

//            return objectContext.GetTableName<T>();
//        }

//        public static string GetTableName<T>(this ObjectContext context) where T : class
//        {
//            string sql = context.CreateObjectSet<T>().ToTraceString();
//            Regex regex = new Regex("FROM (?<table>.*) AS");
//            Match match = regex.Match(sql);

//            string table = match.Groups["table"].Value;
//            return table;
//        }
//    }
//}