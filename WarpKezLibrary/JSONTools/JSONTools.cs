using Newtonsoft.Json;


namespace WarpKezLibrary.JSONTools;

public class JSONTools
{
    // Convert a model to a JSON document
    public string ToJson<T>(T model) => JsonConvert.SerializeObject(model, Formatting.Indented);

    // Convert from JSON document to a model
    public T FromJson<T>(string json)
    {
        T? model = JsonConvert.DeserializeObject<T>(json);

        return model!;
    }
}
