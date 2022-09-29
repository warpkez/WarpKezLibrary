namespace WarpKezLibrary.GuidTools;

public class GuidTools
{
    /// <summary>
    /// Generate a Base64 string from GUID
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public string Guid2URL(Guid guid) => Convert.ToBase64String(guid.ToByteArray())
            .Replace("/", "-")
            .Replace("+", "_")
            .Replace("=", String.Empty);

    /// <summary>
    /// Generate a Base64 string from GUID
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public string GuidToURL(Guid guid)
    {
        return Convert.ToBase64String(guid.ToByteArray())
            .Replace("/", "-")
            .Replace("+", "_")
            .Replace("=", String.Empty);
    }

    /// <summary>
    /// Generate GUID from Base64
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public Guid URLtoGuid(string url)
    {
        var guidstr = Convert.FromBase64String(url
            .Replace("-", "/")
            .Replace("_", "+") + "==");
        return new Guid(guidstr);
    }

    /// <summary>
    /// Generate a new GUID
    /// </summary>
    /// <returns></returns>
    public Guid GenerateGUID() => Guid.NewGuid();
}
