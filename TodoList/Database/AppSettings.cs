
using MongoDB.Driver;
using Newtonsoft.Json;

namespace TodoList.Database;

public class DatabaseSettings
{
    public const string DatabaseSettingsSection = "DatabaseSettings";

    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}