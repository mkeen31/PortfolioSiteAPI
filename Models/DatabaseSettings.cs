namespace PortfolioSiteAPI.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string EducationCollectionName { get; set; } = null!;

        public string ExperienceCollectionName { get; set; } = null!;

        public string EmploymentCollectionName { get; set; } = null!;
    }
}
