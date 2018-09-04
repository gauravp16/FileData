namespace FileData.Services
{
    public interface IFileAttributeService
    {
        string Version(string file);

        string Size(string file);
    }
}
