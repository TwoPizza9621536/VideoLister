using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace VideoLister
{
    /// <summary>
    /// A JSON encoder and decoder for a list of videos with a schema.
    /// </summary>
    public class JsonCodec
    {
        /// <summary>
        /// Encodes Video list to
        /// </summary>
        /// <param name="Videos">List of Videos to be encode</param>
        /// <returns>The JObject of a Video list.</returns>
        public static JObject EncodeJson(List<Video> Videos)
        {
            string RawJson = JsonConvert.SerializeObject(Videos);
            string JsonSchema = "$Schema";
            string SchemaURI =
                "https://twopizza9621536.github.io/schema/json/videolist.json";

            JArray JsonArray = JArray.Parse(RawJson);
            JObject JsonObject = new JObject
            {
                { JsonSchema, SchemaURI }
            };
            JsonObject["Videos"] = JsonArray;
            return JsonObject;
        }

        /// <summary>
        /// Decodes JObject to a immutable Video list.
        /// </summary>
        /// <param name="JsonObject">The JObject to decode.</param>
        /// <returns>A immutable list of Videos.</returns>
        public static IList<Video> DecodeJson(JObject JsonObject)
        {
            JArray JsonArray = (JArray)JsonObject["Videos"];
            IList<Video> Videos = JsonArray.ToObject<IList<Video>>();
            return Videos;
        }
    }
}
