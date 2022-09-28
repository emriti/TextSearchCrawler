using POC_ClassTextCrawler.Models;

namespace POC_ClassTextCrawler.Core
{
    public class CSVFileExporter : IFileExporter
    {
        public void ExportFile(string exportFileFullPath, List<SearchResult> searchResults, char charDelimiter, bool writeHeader = true)
        {
            var properties = typeof(SearchResult).GetProperties();

            using FileStream fs = new FileStream(exportFileFullPath, FileMode.Create, FileAccess.Write);
            using StreamWriter writer = new StreamWriter(fs);

            if (writeHeader)
            {
                var header = "";
                foreach (var prop in properties)
                {
                    header += $"{prop.Name}{charDelimiter}";
                }
                writer.WriteLine(header);
            }

            foreach (var result in searchResults)
            {
                var body = "";
                foreach (var prop in properties)
                {
                    body += $"{prop.GetValue(result)}{charDelimiter}";
                }
                writer.Write($"{body}{System.Environment.NewLine}");
            }
        }
    }
}
