using Newtonsoft.Json.Linq;

namespace C_SeleniumSelfFramework.utilities
{
    public class JsonReader
    {
        public string ExtractData(string tokenName)
        {
            var myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }

        public string[] ExtractDataArray(string tokenName)
        {
            var myJsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectTokens(tokenName).Values<string>().ToArray();
        }
    }
}
