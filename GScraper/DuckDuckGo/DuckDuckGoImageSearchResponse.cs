﻿using System.Text.Json.Serialization;

namespace GScraper.DuckDuckGo;

internal class DuckDuckGoImageSearchResponse
{
    [JsonPropertyName("results")]
    public DuckDuckGoImageResultModel[] Results { get; set; } = null!;
}

internal sealed class DuckDuckGoImageResultModel : DuckDuckGoImageResult
{
    [JsonConstructor]
    public DuckDuckGoImageResultModel(string url, string title, int width,
        int height, string sourceUrl, string thumbnailUrl, string source)
        : base(url, title, width, height, sourceUrl, thumbnailUrl, source)
    {
    }
}