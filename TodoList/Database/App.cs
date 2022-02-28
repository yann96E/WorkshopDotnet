namespace TodoList.Database;

using MongoDB.Driver;
using Newtonsoft.Json;

public class App
{
    public class DatabaseSettings
    {
        public const string DatabaseSettingsSection = "DatabaseSettings";

        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
    }
}