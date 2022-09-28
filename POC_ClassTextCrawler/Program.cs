// See https://aka.ms/new-console-template for more information
using POC_ClassTextCrawler.Core;
using POC_ClassTextCrawler.Models;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();

var inFolder = "C:\\Users\\...\\Net\\Course-Service";
var outFile = "C:\\Users\\...\\file1.csv";
var searchWord = "cachePrefix:";
var delimiter = '|';

Console.WriteLine();
Console.WriteLine(AsciiArt.GetArt);
Console.WriteLine();
sw.Start();

TextExtractor textExtractor = new TextExtractor();
var results = textExtractor.SearchTextFromDirectory(inFolder, searchWord);

Console.WriteLine($"Extracting text done in {sw.ElapsedMilliseconds} ms");
sw.Restart();

IFileExporter exporter = new CSVFileExporter();
exporter.ExportFile(outFile, results, delimiter);

Console.WriteLine($"Exporting text done in {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Done!");
