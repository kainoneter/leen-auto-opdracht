namespace FRCovadis.Shared;

using System.Text.Json;

public static class JsonOptions
{
    public static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}