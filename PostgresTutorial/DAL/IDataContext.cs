using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PostgresTutorial.Model;

namespace PostgresTutorial.DAL
{
    public interface IDataContext
    {
        IEnumerable<string> GetAllTables(string schemaName);

        //IEnumerable<string> GetAllSchemasNames();

        IEnumerable<string> GetAllSchemas();

        DBTable GetAllColumns(string tableName);
    }
}