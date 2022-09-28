using POC_ClassTextCrawler.Models;

namespace POC_ClassTextCrawler.Core
{
    public interface IFileExporter
    {
        void ExportFile(string exportFileFullPath, List<SearchResult> searchResults, char charDelimiter, bool writeHeader = true);
    }
}