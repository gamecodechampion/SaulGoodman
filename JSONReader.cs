using Newtonsoft.Json;

namespace SaulGoodman;

public class JSONReader
{
    public string token { get; set; }
    public string prefix { get; set; }

    public async Task ReadJson()
    {
        using (StreamReader sr = new StreamReader("config.json"))
        {
            string json = await sr.ReadToEndAsync();
            JsonStruct data = JsonConvert.DeserializeObject<JsonStruct>(json);

            this.token = data.token;
            this.prefix = data.prefix;
        }
    }
}

internal sealed class JsonStruct
{
    public string token { get; set; }
    public string prefix { get; set; }
}