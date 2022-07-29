using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedState.SQLite
{
    public class LogTable
    {
        public int Log_Id { get; set; }

        public string Name { get; set; } = "";
        
        public string Message { get; set; } = "";

        public string LoadDate { get; set; } = "";

        public string LoadTime { get; set; } = "";
    }
}
