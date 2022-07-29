using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;

namespace SharedState.SQLite
{
    public class DatabaseConfig
    {
        private static string sqlFile { get; set; } = "mydatabase.sqlite3"; 

        private static string sqlFilePath { get; set; } = $@"./SQLite/{sqlFile}";

        private readonly string connection = $"Data Source={sqlFilePath}";

        private static readonly string createLogTable = $@"CREATE TABLE IF NOT EXISTS LogTable(
                                                                Log_Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                Name TEXT,
                                                                Message TEXT NOT NULL,
                                                                LoadDate TEXT NOT NULL,
                                                                LoadTime TEXT NOT NULL
                                                           )";

        private static SQLiteConnection mySQLiteConnection;

        public DatabaseConfig()
        {
            mySQLiteConnection = new SQLiteConnection(connection);

            if (!File.Exists(sqlFilePath))
            {
                try
                {
                    Console.WriteLine($"{sqlFilePath} creating...");
                    
                    SQLiteConnection.CreateFile(sqlFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{sqlFilePath} is not created, error message: {ex.Message}");
                }
            }

            Console.WriteLine($"{sqlFile} file created");

            Task.Run(() => CreateTable(createLogTable, "LogTable")).Wait();
        }

        public async Task CreateTable(string script, string tableNAme)
        {
            try
            {
                Console.WriteLine($"{tableNAme} creating...");
                
                using var mySQLiteCommand = new SQLiteCommand(script, mySQLiteConnection);
                
                mySQLiteCommand.Connection.Open();
                await mySQLiteCommand.ExecuteNonQueryAsync();
                mySQLiteCommand.Connection.Close();

                Console.WriteLine($"{tableNAme} created!");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"LogTable is not created, error message: {ex.Message}");
            }
        }

        public async Task InsertData(string script, Dictionary<string, object> parameters)
        {
            try
            {
                Console.WriteLine($"Data inserting...");

                using var mySQLiteCommand = new SQLiteCommand(script, mySQLiteConnection);
                
                foreach (var parameter in parameters)
                {
                    mySQLiteCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                mySQLiteCommand.Connection.Open();
                await mySQLiteCommand.ExecuteNonQueryAsync();
                mySQLiteCommand.Connection.Close();

                Console.WriteLine($"Data inserted!");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Data inserting is failed, error message: {ex.Message}");
            }
        }

        public async Task<List<LogTable>> ReadLogData()
        {
            try
            {
                Console.WriteLine($"LogData reading...");

                var readLogData = $@"SELECT * FROM LogTable";

                using var mySQLiteCommand = new SQLiteCommand(readLogData, mySQLiteConnection);

                mySQLiteCommand.Connection.Open();
                using var resultReader = await mySQLiteCommand.ExecuteReaderAsync();

                var logs = new List<LogTable>();

                while (resultReader.Read())
                {
                    logs.Add(new LogTable()
                    {
                        Log_Id = resultReader.GetInt32(0),
                        Name = resultReader.GetString(1),
                        Message = resultReader.GetString(2),
                        LoadDate = resultReader.GetString(3),
                        LoadTime = resultReader.GetString(4),
                    });
                }

                mySQLiteCommand.Connection.Close();

                Console.WriteLine($"Data reading done!");
                
                return logs;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"LogData reading is failed, error message: {ex.Message}");
            }

            return null;
        }
    }
}
