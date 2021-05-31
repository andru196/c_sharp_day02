using System;
using System.Text.Json.Serialization;

namespace d02_ex00.Model
{
    [Serializable]
    
    public class Book : ISearchable
    {
        [JsonPropertyName("title")]
        public string Title  {get;set;}

        [JsonPropertyName("author")]
        public string Author  {get;set;}

        [JsonPropertyName("summaryShort")]
        public string SummaryShort  {get;set;}

        [JsonPropertyName("rank")]
        public uint Rank  {get;set;}

        [JsonPropertyName("listName")]
        public string ListName  {get;set;}

        [JsonPropertyName("url")]
        public string Url  {get;set;}
        
        public override string ToString()
            => $"{Title} by {Author} [{Rank} on NYT’s {ListName}]\n{SummaryShort}\n{Url}";
    }
}