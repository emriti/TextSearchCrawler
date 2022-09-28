namespace POC_ClassTextCrawler.Models
{
    public class SearchResult
    {
        public string? FullFilePath { get; set; }
        public string? FileName { get; set; }
        public long LineNo { get; set; }
        public string? MatchResult { get; set; }
        public string? LineResult { get; set; }

    }
}
