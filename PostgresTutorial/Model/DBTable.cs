using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresTutorial.Model
{
    public class DBTable
    {
        public DBTable(string name)
        {
            Name = name;
            Fields = new Dictionary<string, string>();
        }

        public string Name { get; set; }
        public Dictionary<string, string> Fields { get; set; }
    }
}