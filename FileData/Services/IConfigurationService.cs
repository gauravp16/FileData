namespace FileData.Services
{
    public interface IConfigurationService
    {
        string[] AllowedSizePattern();

        string[] AllowedVersionPattern();
    }
}
