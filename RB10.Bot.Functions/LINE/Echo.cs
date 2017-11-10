using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace RB10.Bot.Functions.LINE
{
    public static class Echo
    {
        [FunctionName("Echo")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("Start");

            // リクエストJSONをパース
            string jsonContent = await req.Content.ReadAsStringAsync();
            Request data = JsonConvert.DeserializeObject<Request>(jsonContent);

            string replyToken = null;
            string messageType = null;
            string echoWord = null;

            // WebAppsのプロパティ設定からデータを取得
            var channelAccessToken = ConfigurationManager.AppSettings["AccessToken"];

            // リクエストデータからデータを取得
            foreach (var item in data.events)
            {
                // リプライデータ送付時の認証トークンを取得
                replyToken = item.replyToken.ToString();
                if (item.message != null)
                {
                    // メッセージタイプを取得、テキスト以外はエラー文言を返却
                    messageType = item.message.type.ToString();
                    if (item.message.text != null)
                    {
                        echoWord = item.message.text.ToString();
                    }
                }
            }

            // リプライデータの作成
            var content = CreateResponse(replyToken, echoWord, log, messageType);

            // JSON形式に変換
            var reqData = JsonConvert.SerializeObject(content);

            // レスポンスの作成
            using (var client = new HttpClient())
            {
                // リクエストデータを作成
                // ※HttpClientで[application/json]をHTTPヘッダに追加するときは下記のコーディングじゃないとエラーになる
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.line.me/v2/bot/message/reply")
                {
                    Content = new StringContent(reqData, Encoding.UTF8, "application/json")
                };

                //　認証ヘッダーを追加
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {channelAccessToken}");

                // 非同期でPOST
                var res = await client.SendAsync(request);

                return req.CreateResponse(res.StatusCode);
            }
        }

        /// <summary>
        /// リプライ情報の作成
        /// </summary>
        /// <param name="token"></param>
        /// <param name="praiseWord"></param>
        /// <param name="log"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        static Response CreateResponse(string token, string praiseWord, TraceWriter log, string messageType = "")
        {
            Response res = new Response();
            Messages msg = new Messages();

            // リプライトークンはリクエストに含まれるリプライトークンを使う
            res.replyToken = token;
            res.messages = new List<Messages>();

            // メッセージタイプがtext以外は単一のレスポンス情報とする
            if (messageType == "text")
            {
                msg.type = "text";
                msg.text = praiseWord;
                res.messages.Add(msg);

            }
            else
            {
                msg.type = "text";
                msg.text = "テキスト以外はエコーできないっす！！";
                res.messages.Add(msg);
            }

            return res;
        }


        //　リクエスト
        public class Request
        {
            public List<Event> events { get; set; }
        }

        //　イベント
        public class Event
        {
            public string replyToken { get; set; }
            public string type { get; set; }
            public object timestamp { get; set; }
            public Source source { get; set; }
            public message message { get; set; }
        }

        // ソース
        public class Source
        {
            public string type { get; set; }
            public string userId { get; set; }
        }

        // リクエストメッセージ
        public class message
        {
            public string id { get; set; }
            public string type { get; set; }
            public string text { get; set; }
        }

        // レスポンス
        public class Response
        {
            public string replyToken { get; set; }
            public List<Messages> messages { get; set; }
        }

        // レスポンスメッセージ
        public class Messages
        {
            public string type { get; set; }
            public string text { get; set; }
        }
    }
}
