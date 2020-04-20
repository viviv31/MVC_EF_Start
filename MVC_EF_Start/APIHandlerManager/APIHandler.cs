using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using MVC_EF_Start.Models;
using Newtonsoft.Json;

namespace MVC_EF_Start.APIHandlerManager
{
    public class APIHandler
    {
        static string BASE_URL = "https://ssd-api.jpl.nasa.gov/sentry.api";
        static string API_KEY = "2DbgzjUw3YVFzbsMRW4FYXpknpTYPrSzMH1Rf8Hz"; //Add your API key here inside ""
        HttpClient httpClient;

        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public SentryObject GetSentryObjects()
        {
            string SENTRY_API_PATH = BASE_URL;
            string sentryRaw = "";
            SentryObject sentryData = null;
            httpClient.BaseAddress = new Uri(SENTRY_API_PATH);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(SENTRY_API_PATH).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    sentryRaw = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!sentryRaw.Equals(""))
                {
                    sentryData = JsonConvert.DeserializeObject<SentryObject>(sentryRaw);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return sentryData;
        }
    }
}
