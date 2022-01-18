using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostgresTutorial.DAL;
using PostgresTutorial.Model;

namespace PostgresTutorial.BLL
{
    public class Operation : IOperation
    {
        private static IDataContext _dataContext;

        public Operation(IDataContext dataContext)
        {
            _dataContext = (DataContext)dataContext;
        }

        public DBTable GetAllColumnsOfTableNames(string tableName)
        {
            return _dataContext.GetAllColumns(tableName);
        }

        public List<string> GetAllSchemas()
        {
            return _dataContext.GetAllSchemas().ToList();
        }

        public List<string> GetAllTableNames(string schemaName)
        {
            return _dataContext.GetAllTables(schemaName).ToList();
        }
    }
}