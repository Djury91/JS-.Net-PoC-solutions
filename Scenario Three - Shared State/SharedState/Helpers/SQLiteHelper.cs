using SharedState.SQLite;

namespace SharedState.Helpers
{
    public static class SQLiteHelper
    {
        public static DatabaseConfig myDatabase { get; set; }

        public static void CreateSQLiteConnection()
        {
            myDatabase = new DatabaseConfig();
        }

        public static void InsertLog(string msg)
        {
            
        }
    }
}
