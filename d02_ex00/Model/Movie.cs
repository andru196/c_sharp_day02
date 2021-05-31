using System;
using System.Text.Json.Serialization;

namespace d02_ex00.Model
{
    [Serializable]
    public class Movie : ISearchable
    {
        [JsonPropertyName("title")]
        public string Title  {get;set;}
        
        [JsonPropertyName("summaryShort")]
        public string SummaryShort  {get;set;}

        [JsonPropertyName("rating")]
        public double Rating  {get;set;}

        [JsonPropertyName("isCriticsPick")]
        public bool IsCriticsPick  {get;set;}

        [JsonPropertyName("url")]
        public string Url  {get;set;}
    }
}