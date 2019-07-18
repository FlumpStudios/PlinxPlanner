namespace PlinxPlanner.Common.Settings
{
    public interface IAppSettings
    {
        API API { get; set; }
        Authentication Authentication { get; set; }
        Database Database { get; set; }
        Swagger Swagger { get; set; }
        Caching Caching { get; set; }
    }
}