using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostgresTutorial.BLL;

namespace PostgresTutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : Controller
    {
        private IOperation _operation;

        public DatabaseController(IOperation operation)
        {
            _operation = operation;
        }

        //https://localhost:44349/Database/GetAllSchemas
        [HttpGet]
        [Route("GetAllSchemas")]
        public IActionResult GetAllSchemas()
        {
            return Ok(_operation.GetAllSchemas());
        }

        //https://localhost:44349/Database/GetAllTables/default_schema
        [HttpGet("GetAllTables/{schemaName}")]
        public IActionResult GetAllTables(string schemaName)
        {
            return Ok(_operation.GetAllTableNames(schemaName));
        }

        //https://localhost:44349/Database/GetAllColumns/sport
        [HttpGet("GetAllColumns/{tableName}")]
        public IActionResult GetAllColumns(string tableName)
        {
            return Ok(_operation.GetAllColumnsOfTableNames(tableName));
        }
    }
}