using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using System.Json;

using System.Net.Http;

namespace c_sharp
{
    class Program
    {

        static String endpointAddress = "http://example.com";


        // .NET 4.5 async example
        static async void simpleAsyncRequest()
        {
            
            using (var httpClient = new HttpClient() { BaseAddress = new Uri(endpointAddress) })
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["retain"] = (1).ToString();
                query["crm/day-orders"] = (121).ToString();
                query["crm/today-emails"] = (234).ToString();
                query["apikey"] = "MDAwMDAwMDAxM0FDRDhDQj==";
                try
                {
                    var response = await httpClient.GetStringAsync("/ncintf/rest/1/openmon/counter?" + query.ToString());
                    Console.WriteLine(response);
                }
                catch (HttpRequestException e)
                {
                       Console.WriteLine("Error: Status " + e.Message);
                }
            }
        }

        // .NET WebRequest synchronous example
        static void simpleWebRequest()
        {

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["retain"] = (1).ToString();
            query["crm/day-orders"] = (121).ToString();
            query["crm/today-emails"] = (234).ToString();
            query["apikey"] = "MDAwMDAwMDAxM0FDRDhDQj==";
            try
            {
                var request = WebRequest.Create(endpointAddress + "?" + query.ToString());
                using (var response = request.GetResponse())
                {
                    using (var stream = new StreamReader(response.GetResponseStream()))
                    {
                        Console.WriteLine(stream.ReadToEnd());
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        static async void jsonAsyncRequest()
        {

            using (var httpClient = new HttpClient() { BaseAddress = new Uri(endpointAddress) })
            {
                var counters = new Dictionary<String,JsonValue>();
                counters["PBX/line status.0"] = 1;
                counters["PBX/line status.1"] = 0;
                counters["PBX/version"] = "Mock Phone System 1.0";

                var data = new Dictionary<string, JsonValue>();
                data["retain"] = 1;
                data["counters"] = counters.ToJsonObject();
                data["apikey"] = "MDAwMDAwMDAxM0FDRDhDQj==";
                try
                {
                    var content = new StringContent(data.ToJsonObject().ToString());
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"){ CharSet = "utf-8" };
                    var response = await httpClient.PostAsync("/ncintf/rest/1/openmon/update", content);
                    Console.WriteLine(response);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Error: Status " + e.Message);
                }
            }            
        }

        static void jsonWebRequest()
        {
            var counters = new Dictionary<String, JsonValue>();
            counters["PBX/line status.0"] = 1;
            counters["PBX/line status.1"] = 0;
            counters["PBX/version"] = "Mock Phone System 1.0";

            var data = new Dictionary<string, JsonValue>();
            data["retain"] = 1;
            data["counters"] = counters.ToJsonObject();
            data["apikey"] = "MDAwMDAwMDAxM0FDRDhDQj==";
            var postData =  Encoding.UTF8.GetBytes(data.ToJsonObject().ToString());
            try
            {
                var request = WebRequest.Create(endpointAddress + "/ncintf/rest/1/openmon/update");
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                
                request.ContentLength = postData.Length;

                Stream dataStream = request.GetRequestStream ();
                dataStream.Write(postData, 0, postData.Length);
                dataStream.Close();
                using (var response = request.GetResponse())
                {
                    using (var stream = new StreamReader(response.GetResponseStream()))
                    {
                        Console.WriteLine(stream.ReadToEnd());
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        static void Main(string[] args)
        {
            simpleAsyncRequest();
            simpleWebRequest();
            jsonAsyncRequest();
            jsonWebRequest();
            System.Threading.Thread.Sleep(5000);
        }
    }
}
