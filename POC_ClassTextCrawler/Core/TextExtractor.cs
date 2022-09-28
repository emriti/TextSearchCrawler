using POC_ClassTextCrawler.Models;
using System.Text.RegularExpressions;

namespace POC_ClassTextCrawler.Core
{
    public class TextExtractor
    {
        public List<SearchResult> SearchTextFromDirectory(string inputDirFullPath, string pattern)
        {
            var files = Directory.EnumerateFiles(inputDirFullPath, "*.cs", SearchOption.AllDirectories);
            List<SearchResult> results = new List<SearchResult>();

            foreach (var file in files)
            {
                var lineNo = 0;
                String[] breakApart = file.Split('\\');
                var fileName = breakApart[breakApart.Length - 1];

                using FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                using StreamReader reader = new StreamReader(fs);
                while (reader.Peek() > 0)
                {
                    ++lineNo;
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        if (Regex.Match(line, pattern).Success)
                        {
                            results.Add(new SearchResult() { 
                                LineNo = lineNo, 
                                FileName = fileName, 
                                MatchResult = Regex.Match(line, pattern).Value, 
                                LineResult = line.Trim(), 
                                FullFilePath = file
                            });
                        }
                    }
                }
            }
            return results;
        }
    }
}
