using SpeechDictionary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using SpeechDictionary.Core;

namespace SpeechDictionary.Core.Services
{
    public class RandomWordService
    {
        public static Definition GetDefinition (string word)
        {
            // 1. Create a HTTP request
            var httpRequest = (HttpWebRequest)HttpWebRequest.Create("https://xkubist-random-word-v1.p.mashape.com/run.cgi");

            // 2. Make this an HTTP POST request. (Remember, GET/POST/UPDATE/DELETE)
            httpRequest.Method = "GET";

            // 3. Add headers to this HTTP request
            httpRequest.Headers.Add("X-Mashape-Key", "3xCAHfneeOmshyaklh4P1vfapeIfp1NmrhGjsn8mIY6YjcCUkt");
            httpRequest.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            httpRequest.Accept = "application/json";

            // 4. Get our response
            var httpResponse = httpRequest.GetResponse();

            // 5. Read the response (which is JSON) and turn it into a Quote object.

            // 5a. Get the stream from the response
            var httpResponseStream = httpResponse.GetResponseStream();

            // 5b. Create an object that can read this Stream in an easy way
            using (var streamReader = new StreamReader(httpResponseStream))
            {
                // 5c. Read the JSON
                string json = streamReader.ReadToEnd();

                var o = JObject.Parse(json);

                var oDefinitions = o["definitions"];
                // 5d. Deserialize into an object
                return JsonConvert.DeserializeObject<Definition>(oDefinitions.First.ToString());
            }

        }
    }
}
