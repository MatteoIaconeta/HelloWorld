using System.Threading.Tasks;

namespace HelloWorld
{
    public interface IFileSystem
    {
        Task WriteTextAsync(string fileName, string text);
    }
}
