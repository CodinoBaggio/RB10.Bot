using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Line.Messaging;
using System.Configuration;
using Newtonsoft.Json;

namespace RB10.Bot.Functions.LINE
{
    public static class Push
    {
        [FunctionName("Push")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");

            //// parse query parameter
            //string name = req.GetQueryNameValuePairs()
            //    .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
            //    .Value;

            //// Get request body
            //dynamic data = await req.Content.ReadAsAsync<object>();

            //// Set name to query string or body data
            //name = name ?? data?.name;

            //return name == null
            //    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            //    : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);



            string jsonContent = await req.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(jsonContent);




            LineMessagingClient lineMessagingClient = new LineMessagingClient(ConfigurationManager.AppSettings["AccessToken"]);


            await lineMessagingClient.PushMessageAsync(ConfigurationManager.AppSettings["AccessToken"], "");



            return null;
        }
    }
}
