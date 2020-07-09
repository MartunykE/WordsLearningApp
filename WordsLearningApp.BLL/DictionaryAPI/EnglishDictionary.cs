using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WordsLearningApp.BLL.Interfaces;

namespace WordsLearningApp.BLL.DictionaryAPI
{
    public class EnglishDictionary : ILanguageDictionary
    {
        string dictionaryAPIKey = "";
        public EnglishDictionary()
        {
            this.dictionaryAPIKey = GetDictionaryKey();
        }
        public string GetWordDefinition(string word)
        {
            string definition = null;
            string requestUrlBase = $"https://www.dictionaryapi.com/api/v3/references/sd3/json/{word}?key={dictionaryAPIKey}";

            Task<HttpResponseMessage> result = SendQueryToApi(requestUrlBase);
            string dictionaryJson = result.Result.Content.ReadAsStringAsync().Result;
            JToken dictionaryToken = null;
            try
            {
                List<JToken> dictionaryMessageTokens = JsonConvert.DeserializeObject<List<JToken>>(dictionaryJson);
                dictionaryToken = dictionaryMessageTokens.FirstOrDefault()["shortdef"];
                for (int i = 0; i < dictionaryToken.Count(); i++)
                {
                    definition += dictionaryToken[i].ToString() + "\n";
                }
            }
            catch
            {

            }
           
            return definition;
        }

        private Task<HttpResponseMessage> SendQueryToApi(string url)
        {
            HttpClient client = new HttpClient();
            return client.GetAsync(url);
        }
        private string GetDictionaryKey()
        {
            string key;
            using (StreamReader reader = new StreamReader("C:\\Users\\realp\\source\\repos\\WordsLearningApp\\WordsLearningApp.BLL\\DictionaryAPI\\DictionarySettings.json"))
            {
                string dictionarySettingsJson = reader.ReadToEnd();
                JObject dictionarySettings = (JObject)JsonConvert.DeserializeObject(dictionarySettingsJson);
                key = dictionarySettings["DictionaryKeys"]["English"].ToString();
            }

            return key;
        }

    }
}
