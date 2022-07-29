using System;
using SharedState.SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Common;
using System.Linq;

namespace SharedState.Helpers
{
    public static class SQLiteHelper
    {
        public static DatabaseConfig myDatabase { get; set; }

        public static void CreateSQLiteConnection()
        {
            myDatabase = new DatabaseConfig();
        }

        public static void InsertLog(string message)
        {
            var insertData = $@"INSERT INTO LogTable(Name, Message, LoadDate, LoadTime)
                                VALUES(@Name, @Message, @LoadDate, @LoadTime)";

            var parameters = new Dictionary<string, object>()
            {
                { "@Name", "Gyuri" },
                { "@Message", message },
                { "@LoadDate", DateTime.UtcNow.ToShortDateString() },
                { "@LoadTime", DateTime.UtcNow.ToShortTimeString() },
            };

            Task.Run(() => myDatabase.InsertData(insertData, parameters)).Wait();
        }

        public static List<LogTable> ReadLog() 
            => Task.Run(() => myDatabase.ReadLogData()).Result;

        public static void DisplayLog()
        {
            var logs = ReadLog();

            if (logs == null)
                Console.WriteLine("Error! Log Data is null!");
            else 
            {
                foreach (var log in logs)
                {
                    Console.WriteLine($"{log.Log_Id,-6} {log.Name,-12} {log.Message,-56} {log.LoadDate,-8} {log.LoadTime,-8}");
                }
                Console.WriteLine(string.Concat(Enumerable.Repeat("===", 3)));
                Console.WriteLine($"Count: {logs.Count}");
            }
        }
    }
}
