using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostgresTutorial.Model;

namespace PostgresTutorial.BLL
{
    public interface IOperation
    {
        DBTable GetAllColumnsOfTableNames(string tableName);

        List<string> GetAllTableNames(string schemaName);

        List<string> GetAllSchemas();
    }
}