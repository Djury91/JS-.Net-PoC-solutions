using System;
using System.Collections.Generic;
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
                                                                Log_Id INTEGER PRIMARY KEY,
                                                                Name TEXT,
                                                                Message TEXT NOT NULL,
                                                                LoadDate TEXT NOT NULL,
                                                                LoadTime TEXT NOT NULL
                                                           ) WITHOUT ROWID";

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

        public static async Task CreateTable(string script, string tableNAme)
        {
            try
            {
                Console.WriteLine($"{tableNAme} creating...");
                using var mySQLiteCommand = new SQLiteCommand(script, mySQLiteConnection);
                mySQLiteCommand.Connection.Open();
                await mySQLiteCommand.ExecuteNonQueryAsync();
                Console.WriteLine($"{tableNAme} created!");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"LogTable is not created, error message: {ex.Message}");
            }
        }

        public static async Task InsertRow(string script, Dictionary<string, object> parameters)
        {
            try
            {
                Console.WriteLine($"Row inserting...");
                using var mySQLiteCommand = new SQLiteCommand(script, mySQLiteConnection);
                mySQLiteCommand.Connection.Open();

                foreach (var parameter in parameters)
                {
                    mySQLiteCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                await mySQLiteCommand.ExecuteNonQueryAsync();
                Console.WriteLine($"Row inserted!");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"LogTable is not created, error message: {ex.Message}");
            }
        }
    }
}
