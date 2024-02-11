// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OpenTextSummarizer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class Program
{
    public static async Task Main(string[] args)
    {
        // var summarizedDocument = OpenTextSummarizer.Summarizer.Summarize(
        // new OpenTextSummarizer.FileContentProvider(@"C:\Users\india\Downloads\Transcription.txt"),
        // new SummarizerArguments() 
        // {
        //     Language = "en",
        //     MaxSummarySentences = 5
        // });
        // Console.WriteLine(summarizedDocument);
        SummarizeThis(new OpenTextSummarizer.FileContentProvider(@"C:\Users\india\Downloads\Temp.txt"));
    }
    private static void SummarizeThis(IContentProvider contentProvider)
        {
            var summarizedDocument = OpenTextSummarizer.Summarizer.Summarize(
                contentProvider,
                new OpenTextSummarizer.SummarizerArguments() { Language = "en", MaxSummarySentences = 5 });

            Console.WriteLine("Summarizing content from " + contentProvider.GetType().FullName);
            Console.WriteLine(" ===== Concepts =============================== ");
            summarizedDocument.Concepts.ForEach(c => Console.WriteLine(string.Format("\t{0}", c)));
            Console.WriteLine(" ===== Summary =============================== ");
            summarizedDocument.Sentences.ForEach(s => Console.WriteLine(string.Format("{0}", s)));
            Console.ReadKey();
        }
}
