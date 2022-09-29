namespace WarpKezLibrary.GuidTools;

public class GuidTools
{
    // Generate a URL safe (it is alread) string
    public string Guid2URL(Guid guid) => Convert.ToBase64String(guid.ToByteArray())
            .Replace("/", "-")
            .Replace("+", "_")
            .Replace("=", String.Empty);

    // Generate a URL safe (it is alread) string
    public string GuidToURL(Guid guid)
    {
        return Convert.ToBase64String(guid.ToByteArray())
            .Replace("/", "-")
            .Replace("+", "_")
            .Replace("=", String.Empty);
    }

    // Generate the GUID from the URL safe string
    public Guid URLtoGuid(string url)
    {
        var guidstr = Convert.FromBase64String(url
            .Replace("-", "/")
            .Replace("_", "+") + "==");
        return new Guid(guidstr);
    }

    // Why?  Not really as useful as originally thought
    public Guid GenerateGUID() => Guid.NewGuid();
}
